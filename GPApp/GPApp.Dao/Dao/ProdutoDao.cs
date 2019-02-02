using GPApp.Model;
using GPApp.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPApp.Dal.Dao
{
    public class ProdutoDao : IProdutoDao
    {
        public async Task IncluirAsync(Produto produto) 
        {
            using (var db = DatabaseManager.GetContext())
            {
                IncluiPosicaoEstoque(produto);
                await db.Produtos.AddAsync(produto);
                await db.SaveChangesAsync();
            }
        }

        public async Task IncluirAsync(IEnumerable<Produto> produtos)
        {
            using (var db = DatabaseManager.GetContext())
            {
                foreach (var pro in produtos)
                {
                    IncluiPosicaoEstoque(pro);
                }
                await db.Produtos.AddRangeAsync(produtos);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<string>> Atualiza(Produto produto)
        {
            using (var db = DatabaseManager.GetContext())
            {
                var imagensExcluidas = new List<string>();
                var produtoDb = await LocalizarPorChavePrimaria(produto.Id);

                AtualizaPosicaoEstoque(produto, produtoDb);

                VerificarExclusaoDeImagens(produto, db, imagensExcluidas, produtoDb);
                VerificarExclusaoDeEspecificacoes(produto, db, produtoDb);

                db.Produtos.Update(produto);
                await db.SaveChangesAsync();
                return imagensExcluidas;
            }
        }

        public async Task<Dictionary<Guid, IEnumerable<string>>> Atualiza(IEnumerable<Produto> produtos)
        {
            var ids = produtos.Select(p => p.Id);

            var itensAExcluir = new Dictionary<Guid, IEnumerable<string>>();

            using (var db = DatabaseManager.GetContext())
            {
                var dbProdutos = await db.Produtos
                                          .Where(p => ids.Contains(p.Id))
                                          .ToDictionaryAsync(p => p.Id);

                List<string> imagensAExcluir = new List<string>();
                foreach (var produto in produtos)
                {
                    var produtoDb = dbProdutos[produto.Id];
                    VerificarExclusaoDeImagens(produto, db, imagensAExcluir, produtoDb);
                    VerificarExclusaoDeEspecificacoes(produto, db, produtoDb);
                    itensAExcluir.Add(produto.Id, imagensAExcluir);
                    AtualizaPosicaoEstoque(produto, produtoDb);
                }

                db.Produtos.UpdateRange(produtos);
            }
            return itensAExcluir; 
        }
                
        public async Task<IEnumerable<Produto>> TodosComImagemAsync()
        {
            using (var db = DatabaseManager.GetContext())
            {
                return await db.Produtos
                    .Include(p=> p.Imagens)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Produto>> TodosAsync()
        {
            using (var db = DatabaseManager.GetContext())
            {
                return await db.Produtos.ToListAsync();
            }
        }

        public async Task<Produto> LocalizarPorChavePrimaria(Guid id)
        {
            using (var db = DatabaseManager.GetContext())
            {
                var produto = await db.Produtos
                    .Include(p => p.Imagens)
                    .Include(p => p.Especificacoes)
                    .FirstOrDefaultAsync(p => p.Id == id);

                var estoqueAtual = await db.Estoques
                                        .Where(e=> e.ProdutoId == id)           
                                        .OrderByDescending(p => p.Lancamento)
                                        .FirstOrDefaultAsync();

                produto.EstoqueAtual = estoqueAtual?? new ProdutoEstoque();

                return produto;
            }
        }

        public async Task<IEnumerable<Produto>> BuscaProdutosNaoSincronizados()
        {
            using (var db = DatabaseManager.GetContext())
            {
                var produtos = await db.Produtos
                              .Where(p => !p.Sincronizado)
                              .Select(p => new Produto
                              {
                                  Id = p.Id,
                                  Nome = p.Nome,
                                  Codigo = p.Codigo,
                                  Descricao = p.Descricao,
                                  Preco = p.Preco,
                                  PrecoPromocional = p.PrecoPromocional,
                                  Custo = p.Custo,
                                  DataCadastro = p.DataCadastro,
                                  EstoqueAtual = p.PosicoesEstoque.OrderByDescending(e=> e.Lancamento).FirstOrDefault(),
                                  Imagens = p.Imagens,
                                  Especificacoes = p.Especificacoes,
                                  PosicoesEstoque = new List<ProdutoEstoque>()
                              })
                              .ToListAsync();

                return produtos;
            }
        }

        public async Task AtualizaSincronizacaoAsync(IEnumerable<Guid> ids, DateTimeOffset dataAtualizacao)
        {
            using (var db = DatabaseManager.GetContext())
            {
                var dbProdutos = db.Produtos.Where(p => ids.Contains(p.Id));
                foreach (var dbProduto in dbProdutos )
                {
                    dbProduto.Sincronizado = true;
                    dbProduto.UltimaAtualizacao = dataAtualizacao;
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Guid>> GetIdsCadastradosAsync(IEnumerable<Guid> ids)
        {
            using (var db = DatabaseManager.GetContext())
            {
                return await db.Produtos
                        .AsNoTracking()
                        .Where(p => ids.Contains(p.Id))
                        .Select(p=> p.Id)
                        .ToListAsync();
            }
        }

        public async Task<int> ProdutoNaoSincronizadosAsync()
        {
            using (var db = DatabaseManager.GetContext())
            {
                return await db.Produtos
                    .Where(p => !p.Sincronizado)
                    .CountAsync();
            }
        }

        #region Métodos auxiliares

        private void VerificarExclusaoDeEspecificacoes(Produto produto, GPDataContext db, Produto produtoDb)
        {
            foreach (var espe in produtoDb.Especificacoes.ToList())
            {
                if (produto.Especificacoes.Any(p => p.Id == espe.Id)) continue;
                db.Especificacoes.Remove(espe);
            }
        }

        private void VerificarExclusaoDeImagens(Produto produto, GPDataContext db, List<string> imagensExcluidas, Produto produtoDb)
        {
            foreach (var imagem in produtoDb.Imagens.ToList())
            {
                if (produto.Imagens.Any(p => p.Id == imagem.Id)) continue;
                db.Imagens.Remove(imagem);

                imagensExcluidas.Add(ImagemHelper.GeraCaminho(imagem, ImagemHelper.Tamanho.Pequeno, produto.Id));
                imagensExcluidas.Add(ImagemHelper.GeraCaminho(imagem, ImagemHelper.Tamanho.Original, produto.Id));
            }
        }


        private static void IncluiPosicaoEstoque(Produto produto)
        {
            var estoque = new ProdutoEstoque
            {
                Lancamento = DateTime.UtcNow,
                Quantidade = produto.EstoqueAtual.Quantidade
            };

            
            produto.PosicoesEstoque.Clear();
            produto.PosicoesEstoque.Add(estoque);
        }

        private static void AtualizaPosicaoEstoque(Produto produto, Produto produtoDb)
        {
            if (produtoDb.EstoqueAtual.Quantidade != produto.EstoqueAtual.Quantidade)
            {
                IncluiPosicaoEstoque(produto);
            }
        }

        #endregion
    }
}
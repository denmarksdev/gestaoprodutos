using GPApp.Model;
using GPApp.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
                await db.Produtos.AddAsync(produto);
                await db.SaveChangesAsync();
            }
        }

        public async Task IncluirAsync(IEnumerable<Produto> produtos)
        {
            using (var db = DatabaseManager.GetContext())
            {
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

                VerificarExclusaoDeImagens(produto, db, imagensExcluidas, produtoDb);
                VerificarExclusaoDeEspecificacoes(produto, db, produtoDb);

                db.Produtos.Update(produto);
                await db.SaveChangesAsync();
                return imagensExcluidas;
            }
        }

        public async Task<IEnumerable<string>> Atualiza(IEnumerable<Produto> produtos)
        {
            var ids = produtos.Select(p => p.Id);
            List<string> imagensAExcluir = new List<string>();

            using (var db = DatabaseManager.GetContext())
            {
                var dbProdutos = await db.Produtos
                                          .Where(p => ids.Contains(p.Id))
                                          .ToDictionaryAsync(p => p.Id);

                foreach (var produto in produtos)
                {
                    var produtoDb = dbProdutos[produto.Id];
                    VerificarExclusaoDeImagens(produto, db, imagensAExcluir, produtoDb);
                    VerificarExclusaoDeEspecificacoes(produto, db, produtoDb);
                }

                db.Produtos.UpdateRange(produtos);
            }
            return imagensAExcluir;
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
                                        .OrderBy(p => p.Lancamento)
                                        .FirstOrDefaultAsync();

                produto.EstoqueAtual = estoqueAtual;

                return produto;
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
        
        #endregion
    }
}
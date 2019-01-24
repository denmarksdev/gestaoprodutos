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
        public async Task<IEnumerable<Produto>> TodosAsync()
        {
            using (var db = DatabaseManager.GetContext())
            {
                return await db.Produtos.ToListAsync();
            }
        }

        public async Task IncluirAsync(Produto produto) 
        {
            using (var db = DatabaseManager.GetContext())
            {
                await db.Produtos.AddAsync(produto);
                await db.SaveChangesAsync();
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

        public async Task<List<string>> Atualiza(Produto produto)
        {
            using (var db = DatabaseManager.GetContext())
            {
                var imagensExcluidas = new List<string>();
                var produtoDb = await LocalizarPorChavePrimaria(produto.Id);

                foreach (var imagem in produtoDb.Imagens.ToList())
                {
                    if (produto.Imagens.Any(p => p.Id == imagem.Id)) continue;
                    db.Imagens.Remove(imagem);

                    imagensExcluidas.Add(ImagemHelper.GeraCaminho(imagem, ImagemHelper.Tamanho.Pequeno, produto.Id));
                    imagensExcluidas.Add(ImagemHelper.GeraCaminho(imagem, ImagemHelper.Tamanho.Original, produto.Id));
                }

                foreach (var espe in produtoDb.Especificacoes.ToList())
                {
                    if (produto.Especificacoes.Any(p => p.Id == espe.Id)) continue;
                    db.Especificacoes.Remove(espe);
                }

                db.Produtos.Update(produto); 

                await db.SaveChangesAsync();

                return imagensExcluidas;
            }
        }
    }
}

using GPApp.Dal.Dao;
using GPApp.Model;
using GPApp.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPApp.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public IProdutoDao _dao = new ProdutoDao();

        public async Task<Resultado<IEnumerable<Produto>>> TodosAsyc()
        {
            try
            {
                return new Resultado<IEnumerable<Produto>>(await _dao.TodosAsync());
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<Produto>>("Falha ao buscar os produtos", ex);
            }
        }

        public async Task<Resultado> IncluirAsync (Produto produto)
        {
            try
            {
                produto.PosicoesEstoque.Add(produto.EstoqueAtual);
                await _dao.IncluirAsync(produto);
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<Produto>>("Falha ao incluir o produto " + produto.Nome, ex);
            }
        }

        public async Task<Resultado<Produto>> LocalizaPorChavePrimariaAsync(Guid id)
        {
            try
            {
                var produto = await _dao.LocalizarPorChavePrimaria(id);
                return new Resultado<Produto>(produto);
            }
            catch (Exception ex)
            {
                return new Resultado<Produto>("Falha ao localizar o id " + id.ToString(), ex);
            }
        }

        public async Task<Resultado<List<string>>> AtualizaAsync(Produto produto)
        {
            try
            {
               var imagensExcluidas = await _dao.Atualiza(produto);
                return new Resultado<List<string>>(imagensExcluidas);
            }
            catch (Exception ex)
            {
                return new Resultado<List<string>>("Falha ao atualizar o produto o " +  produto.Nome, ex);
            }
        }
    }
}
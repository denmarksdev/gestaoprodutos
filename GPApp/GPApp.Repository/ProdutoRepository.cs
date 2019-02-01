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

        public async Task<Resultado<IEnumerable<Produto>>> TodosComImagemAsyc()
        {
            try
            {
                return new Resultado<IEnumerable<Produto>>(await _dao.TodosComImagemAsync());
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

        public async Task<Resultado<IEnumerable<string>>> AtualizaAsync(Produto produto)
        {
            try
            {
               var imagensExcluidas = await _dao.Atualiza(produto);
                return new Resultado<IEnumerable<string>>(imagensExcluidas);
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<string>>("Falha ao atualizar o produto o " +  produto.Nome, ex);
            }
        }

        public async Task<Resultado> IncluirAsync(IEnumerable<Produto> produtos)
        {
            try
            {
                await _dao.IncluirAsync(produtos);
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado("Falha ao incluir os produtos", ex);
            }
        }

        public Task<Resultado<Dictionary<Guid, string>>> AtualizaAsync(IEnumerable<Produto> produto)
        {
            throw new NotImplementedException();
        }

        public async Task<Resultado<IEnumerable<Produto>>> BuscaProdutosNaoSincronizados()
        {
            try
            {
                IEnumerable<Produto> produtos = await _dao.BuscaProdutosNaoSincronizados();
                return new Resultado<IEnumerable<Produto>>(produtos);
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<Produto>>("Falha ao localizar produtos não sincronizados", ex);
            }
        }

        public async Task<Resultado> AtualizaSincronizacaoAsync(IEnumerable<Guid> ids, DateTimeOffset dataAtualizacao)
        {
            try
            {
                await _dao.AtualizaSincronizacaoAsync(ids, dataAtualizacao); 
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado("Falha ao atualizar sincronização", ex);
            }
        }
    }
}
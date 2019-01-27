using GPApp.Dal.Base;
using GPApp.Model;
using GPApp.Model.Lookups;
using GPApp.Shared.Dados;
using GPApp.Shared.Paginacao;
using GPApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GPApp.Repository
{
    public class ProdutoPaginacaoRepository : IPaginacaoRepository<ProdutoLookupWrapper>
    {
        private readonly IGenericPaginacaoDao<Produto> _dao;

        public ProdutoPaginacaoRepository()
        {
            _dao = new GenericPaginacaoDao<Produto>
            {
                FiltroFunc = OnFiltro
            };
        }

        private Expression<Func<Produto, bool>> OnFiltro()
        {
            DateTime.TryParse(Pesquisa, out DateTime data);
            Guid.TryParse(Pesquisa, out Guid id);
            decimal.TryParse(Pesquisa, out decimal valorDecimal);

            return p =>
                p.Id == id ||
                p.Codigo == Pesquisa ||
                p.Nome.Contains(Pesquisa) ||
                p.Preco == valorDecimal ||
                p.DataCadastro == data;
        }

        public string Pesquisa
        {
            get => _dao.Pesquisa;
            set => _dao.Pesquisa = value;
        }
        public string Ordem
        {
            get => _dao.Ordem ;
            set => _dao.Ordem = value;
        }

        public int Count => _dao.Count();

        public IEnumerable<ProdutoLookupWrapper> GetItens(int limit, int offset)
        {
            return _dao.GetItens(limit, offset, p => p.PosicoesEstoque)
                .Select(p => new ProdutoLookupWrapper(new ProdutoLookup(p)))
                .ToList();
        }

        public IEnumerable<ProdutoLookupWrapper> GetItens(object[] ids)
        {
            return _dao.GetItens(p => ids.Contains(p.Id))
                        .Select(p => new ProdutoLookupWrapper(new ProdutoLookup(p)))
                        .ToList();
        }

        public IEnumerable<ProdutoLookupWrapper> GetItens()
        {
           return _dao.GetItens()
                    .Select(p => new ProdutoLookupWrapper(new ProdutoLookup(p)))
                    .ToList();
        }

        public int GetPosicaoLinha(object id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GPApp.Model;

namespace GPApp.Shared.Dados
{
    public interface IGenericPaginacaoDao<TEntity> where TEntity : class
    {
        Func<Expression<Func<TEntity, bool>>> FiltroFunc { get; set; }
        string Ordem { get; set; }
        string Pesquisa { get; set; }

        int Count();

        IEnumerable<TEntity> GetItens(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetItens(int limit, int offset, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetItens(Expression<Func<TEntity,bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
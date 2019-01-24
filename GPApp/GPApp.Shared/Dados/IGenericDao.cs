using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GPApp.Shared.Dados
{
    public interface IGenericDao<T> where T : class
    {
        Task AtualizarAsync(T entity);
        Task ExcluiAsync(object id);
        Task IncluiAsync(T entity);
        Task<IEnumerable<T>> LocalizaPorAsync(Expression<Func<T, bool>> predicate);
        Task<T> LocalizaPorChavePrimariaAsync(object id);
        Task<IEnumerable<T>> LocalizaPorComInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> TodosAsyc();
        Task<IEnumerable<T>> TodosComIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
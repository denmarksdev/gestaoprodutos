using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GPApp.Model.Helpers;

namespace GPApp.Shared.Dados
{
    public interface IGenericRepository<T>
    {
        Task<Resultado> AtualizarAsync(T entity);
        Task<Resultado> ExcluiAsync(object id);
        Task<Resultado> IncluiAsync(T entity);
        Task<Resultado<IEnumerable<T>>> LocalizaPorAsync(Expression<Func<T, bool>> predicate);
        Task<Resultado<T>> LocalizaPorChavePrimariaAsync(object id);
        Task<Resultado<IEnumerable<T>>> LocalizaPorComInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<Resultado<IEnumerable<T>>> TodosAsyc();
        Task<Resultado<IEnumerable<T>>> TodosComIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
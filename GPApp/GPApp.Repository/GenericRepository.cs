using GPApp.Dal.Dao;
using GPApp.Model.Helpers;
using GPApp.Shared.Dados;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GPApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private Lazy<IGenericDao<T>> _dao = new Lazy<IGenericDao<T>>(new Func<IGenericDao<T>>(Inicializa));
        private static IGenericDao<T> Inicializa()
        {
            return new GenericDao<T>();
        }

        public GenericRepository()
        {
        }

        public async Task<Resultado<IEnumerable<T>>> TodosAsyc()
        {
            try
            {
                return new Resultado<IEnumerable<T>>(await _dao.Value.TodosAsyc());
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<T>>("Falha ao buscar os itens", ex);
            }
        }

        public async Task<Resultado<IEnumerable<T>>> TodosComIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                return new Resultado<IEnumerable<T>>( await _dao.Value.TodosComIncludeAsync(includeProperties));
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<T>>("Falha ao buscar os itens com propriedades adicionais", ex);
            }
        }

        public async Task<Resultado> ExcluiAsync(object id)
        {
            try
            {
                await _dao.Value.ExcluiAsync(id);
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado(string.Format("Falha ao exluir o item {0}", id), ex, false);
            }
        }

        public async Task<Resultado<IEnumerable<T>>> LocalizaPorAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return new Resultado<IEnumerable<T>>(await _dao.Value.LocalizaPorAsync(predicate));
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<T>>("Falha ao econtrar os itens por", ex);
            }
        }

        public async Task<Resultado<IEnumerable<T>>> LocalizaPorComInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                return new Resultado<IEnumerable<T>>( await _dao.Value.LocalizaPorComInclude(predicate, includeProperties));
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<T>>("Falha ao buscar os itens por com propriedades adicionais", ex);
            }
        }

        public async Task<Resultado<T>> LocalizaPorChavePrimariaAsync(object id)
        {
            try
            {
                return new Resultado<T>( await _dao.Value.LocalizaPorChavePrimariaAsync(id));
            }
            catch (Exception ex)
            {
                return new Resultado<T>("Falha ao localizar o item pela chave", ex);
            }
        }

        public async Task<Resultado> IncluiAsync(T entity)
        {
            try
            {
                await this._dao.Value.IncluiAsync(entity);
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado("Falha ao incluir o item", ex, false);
            }
        }

        public async Task<Resultado> AtualizarAsync(T entity)
        {
            try
            {
                await _dao.Value.AtualizarAsync(entity);
                return new Resultado();
            }
            catch (Exception ex)
            {
                return new Resultado("Falha ao atualizar o item", ex, false);
            }
        }
    }
}
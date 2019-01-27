using GPApp.Helpers;
using GPApp.Shared.Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GPApp.Dal.Base
{
    public class GenericPaginacaoDao<TEntity> : IGenericPaginacaoDao<TEntity> where TEntity:class
    {
        #region Membros

        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public string Pesquisa { get; set; }
        public string Ordem { get; set; }

        public Func<Expression<Func<TEntity,bool>>> FiltroFunc { get; set; }

        #endregion

        #region Construtor

        public GenericPaginacaoDao()
        {
            _context = DatabaseManager.GetContext();
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Métodos

        public IEnumerable<TEntity> GetItens(int limit, int offset, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (string.IsNullOrEmpty(Pesquisa))
                return ItensSemFiltro(limit, offset, includeProperties);

            return Filtra(limit, offset);
        }

        public IEnumerable<TEntity> GetItens(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AddIncludes(includeProperties).Where(predicate);
        }

        public IEnumerable<TEntity> GetItens(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AddIncludes(includeProperties);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        private IEnumerable<TEntity> ItensSemFiltro(int limit, int offset, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AddIncludes(includeProperties)
                       .OrderBy(Ordem)
                       .Skip(offset)
                       .Take(limit);
        }

        private IQueryable<TEntity> AddIncludes(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> seed = _dbSet.AsNoTracking();
            return ((IEnumerable<Expression<Func<TEntity, object>>>)includeProperties)
                .Aggregate(seed, (current, includeProperty) =>
                               current.Include(includeProperty));
        }

        private IEnumerable<TEntity> Filtra(int limit, int offset, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var filtro = FiltroFunc?.Invoke();
            if (filtro == null) return ItensSemFiltro(limit, offset);

            return AddIncludes(includeProperties).Where(filtro);
        }

        #endregion
    }
}
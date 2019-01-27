using GPApp.Dal.Helpers;
using GPApp.Shared.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GPApp.Dal.Base
{
    public class GenericDao<TEntity> : IGenericDao<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericDao(DbContext context)
        {
            _context = context;
            _dbSet = this._context.Set<TEntity>();
        }

        public GenericDao()
        {
            _context = DatabaseManager.GetContext();
            _dbSet = this._context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> TodosAsyc() => await _dbSet.AsNoTracking().ToListAsync(new CancellationToken());

        private IQueryable<TEntity> TodosComInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> seed = _dbSet.AsNoTracking();
            return ((IEnumerable<Expression<Func<TEntity, object>>>)includeProperties)
                .Aggregate(seed, (current, includeProperty) => 
                               current.Include(includeProperty));
        }

        public async Task<IEnumerable<TEntity>> LocalizaPorAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                    .Where(predicate)
                    .ToListAsync(new CancellationToken());
        }

        public Task<TEntity> LocalizaPorChavePrimariaAsync(object id)
        {
            return _dbSet.AsNoTracking()
                    .SingleOrDefaultAsync(DataContextHelper.BuildLambdaForFindByKey<TEntity>(id));
        }

        public async Task IncluiAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await this._dbSet.AddAsync(entity, new CancellationToken());
            int num = await _context.SaveChangesAsync(new CancellationToken());
            Console.WriteLine("Resultado da inclusão => {0}", num);
        }

        public async Task ExcluiAsync(object id)
        {
            _dbSet.Remove( await LocalizaPorChavePrimariaAsync(id));
            int num = await _context.SaveChangesAsync(new CancellationToken());
            Console.WriteLine("Resultado da exclusão id:{0} => {1}", num);
        }

        public async Task AtualizarAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
        }

        public async Task<IEnumerable<TEntity>> LocalizaPorComInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await TodosComInclude(includeProperties).Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> TodosComIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> seed = TodosComInclude(includeProperties);

            return await seed.ToListAsync();
        }
    }
}
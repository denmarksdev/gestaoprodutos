using System;
using System.Linq.Expressions;

namespace GPApp.Dal.Helpers
{
    static class DataContextHelper
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(object id)
        {

            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UcakBiletim.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params string[] includeProperties) where T : class, new()
        {
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }
    }
}

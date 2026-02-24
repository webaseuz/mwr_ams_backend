using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bms.WEBASE.EF.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> IncludeMultiple<TEntity>(
        this IQueryable<TEntity> query,
        params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
    {
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }
}
using Bms.WEBASE.Models;
namespace Bms.Core.Application;

public static class StatusSpecification
{
    public static IQueryable<T> IsNotSoftDeleted<T>(this IQueryable<T> query)
        where T : ISoftDeletable
        => query.Where(q => q.IsDeleted == false);

    public static IQueryable<T> IsNotDeleted<T>(this IQueryable<T> query)
        where T : IHaveIsDeleted
        => query.Where(q => q.IsDeleted == false);
}

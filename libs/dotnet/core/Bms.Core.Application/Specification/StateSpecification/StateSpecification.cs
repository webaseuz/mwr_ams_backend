using Bms.Core.Domain;
using Bms.WEBASE.Models;
namespace Bms.Core.Application;

public static class StateSpecification
{
    public static IQueryable<T> IsActive<T>(this IQueryable<T> query)
        where T : IHaveStateId
        => query.Where(q => q.StateId == StateIdConst.ACTIVE);

    public static IQueryable<T> IsSoftActive<T>(this IQueryable<T> query)
        where T : IHaveSoftStateId
        => query.Where(q => q.StateId == StateIdConst.ACTIVE);
}

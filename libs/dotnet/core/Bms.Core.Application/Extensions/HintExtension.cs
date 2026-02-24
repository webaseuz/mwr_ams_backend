using Bms.WEBASE.Models;
using System.Linq.Expressions;

namespace Bms.Core.Application;

public static class HintExtension
{
    public static IQueryable<T> WithHint<T>(this IQueryable<T> set,
                                            string hint) where T : class
    {
        HintInterceptor.HintValue = hint;
        return set;
    }
    public static IQueryable<T> ForUpdate<T>(this IQueryable<T> set) where T : class
    {
        return set.WithHint("FOR UPDATE");
    }

    public static void Lock<T>(this IQueryable<T> set, Expression<Func<T, bool>> predicate)
        where T : class
    {
        set.Where(predicate).Select(a => new { field = 1 }).ForUpdate().ToArray();
    }

    public static void Lock<TId, T>(this IQueryable<T> set, params TId[] ids)
        where T : class, IHaveIdProp<TId>
    {
        if (ids.Length > 0)
            set.Where(a => ids.Contains(a.Id)).Select(a => new { a.Id }).ForUpdate().ToArray();
    }
}
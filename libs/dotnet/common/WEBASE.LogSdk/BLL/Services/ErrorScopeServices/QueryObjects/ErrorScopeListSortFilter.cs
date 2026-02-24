using System.Linq.Dynamic.Core;
using WEBASE.LogSdk.Core.Helpers;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;

public static class ErrorScopeListSortFilter
{
    public static IQueryable<ErrorScopeDto> SortFilter(this IQueryable<ErrorScopeDto> query, ErrorScopeOption options)
    {
        if (options.HasSearch())
            query = query.Where(a => a.NormalizedRequestPath.ToLower().Contains(options.Search.ToLower()) ||
                                     a.Title.ToLower().Contains(options.Search.ToLower()) ||
                                     a.HostName.ToLower().Contains(options.Search.ToLower()));

        if (options.IsFixed is not null)
            query = query.Where(x => x.IsFixed == options.IsFixed);

        if (options.IsDaily)
        {
            string scopekey = ScopeIntervalHelper.GetKey(DateTime.Now);
            query = query.Where(x => x.ScopeKey == scopekey);
        }

        if (options.HasSort())
            query = query.OrderBy($"{options.SortBy} {options.OrderType}");
        else
            query = query.OrderBy($"{nameof(ErrorScope.Id)} {SortFilterPageOptions.ORDER_TYPE_DESC}");

        return query;
    }
}

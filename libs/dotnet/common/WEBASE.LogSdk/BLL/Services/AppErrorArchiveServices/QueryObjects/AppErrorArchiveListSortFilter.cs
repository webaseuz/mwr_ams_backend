using System.Linq.Dynamic.Core;
using WEBASE.LogSdk.DAL.EfClasses;
using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;

public static class AppErrorArchiveListSortFilter
{
    public static IQueryable<AppErrorArchive> SortFilter(this IQueryable<AppErrorArchive> query, SortFilterPageOptions options)
    {
        if (options.HasSearch())
            query = query.Where(a => a.RequestPath.ToLower().Contains(options.Search.ToLower()) ||
                                     a.Title.ToLower().Contains(options.Search.ToLower()) ||
                                     a.HostName.ToLower().Contains(options.Search.ToLower()));

        if (options.HasSort())
            query = query.OrderBy($"{options.SortBy} {options.OrderType}");
        else
            query = query.OrderBy($"{nameof(AppError.Id)} {SortFilterPageOptions.ORDER_TYPE_DESC}");

        return query;
    }
}

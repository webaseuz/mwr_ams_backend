using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public static class GetBatteryTypeBriefPagedResultSortFilter
{
    public static IQueryable<BatteryTypeBriefDto> SortFilter(
        this IQueryable<BatteryTypeBriefDto> query,
        GetBatteryTypeBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<BatteryTypeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

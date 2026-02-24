using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public static class GetLiquidTypeBriefPagedResultSortFilter
{
    public static IQueryable<LiquidTypeBriefDto> SortFilter(
        this IQueryable<LiquidTypeBriefDto> query,
        GetLiquidTypeBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<LiquidTypeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderBy(a => a.Id);

        return query;
    }
}

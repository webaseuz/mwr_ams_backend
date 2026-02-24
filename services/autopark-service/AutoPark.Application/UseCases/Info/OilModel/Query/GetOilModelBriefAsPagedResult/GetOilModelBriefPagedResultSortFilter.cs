using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.OilModels;

public static class GetOilModelBriefPagedResultSortFilter
{
    public static IQueryable<OilModelBriefDto> SortFilter(
        this IQueryable<OilModelBriefDto> query,
        GetOilModelBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<OilModelBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

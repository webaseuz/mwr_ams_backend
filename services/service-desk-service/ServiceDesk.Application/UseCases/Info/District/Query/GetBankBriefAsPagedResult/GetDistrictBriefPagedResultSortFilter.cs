using System.Linq.Dynamic.Core;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.Districts;

public static class GetDistrictBriefPagedResultSortFilter 
{
    public static IQueryable<DistrictBriefDto> SortFilter(
        this IQueryable<DistrictBriefDto> query,
        GetDistrictBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.Code.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<DistrictBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

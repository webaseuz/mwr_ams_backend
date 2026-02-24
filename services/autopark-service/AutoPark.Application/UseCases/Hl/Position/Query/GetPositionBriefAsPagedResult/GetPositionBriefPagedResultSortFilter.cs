using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Positions;

public static class GetPositionBriefPagedResultSortFilter
{
    public static IQueryable<PositionBriefDto> SortFilter(
        this IQueryable<PositionBriefDto> query,
        GetPositionBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.Code.ToLower().Contains(target) ||
                                     a.OrderCode.ToLower().Contains(target));

        }

        if (request.HasSort() && request.IsValidSortBy<PositionBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

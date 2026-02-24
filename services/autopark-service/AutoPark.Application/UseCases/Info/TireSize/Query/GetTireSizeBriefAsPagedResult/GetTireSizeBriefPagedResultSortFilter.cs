using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.TireSizes;

public static class GetTireSizeBriefPagedResultSortFilter
{
    public static IQueryable<TireSizeBriefDto> SortFilter(
        this IQueryable<TireSizeBriefDto> query,
        GetTireSizeBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.OrderCode.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<TireSizeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

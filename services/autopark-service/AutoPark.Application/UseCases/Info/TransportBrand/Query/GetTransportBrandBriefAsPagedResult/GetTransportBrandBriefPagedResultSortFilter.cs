using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.TransportBrands;

public static class GetTransportBrandBriefPagedResultSortFilter
{
    public static IQueryable<TransportBrandBriefDto> SortFilter(
        this IQueryable<TransportBrandBriefDto> query,
        GetTransportBrandBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<TransportBrandBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

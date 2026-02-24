using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.FuelTypes;

public static class GetFuelTypeBriefPagedResultSortFilter
{
    public static IQueryable<FuelTypeBriefDto> SortFilter(
        this IQueryable<FuelTypeBriefDto> query,
        GetFuelTypeBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<FuelTypeBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

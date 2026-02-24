using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Countries;

public static class GetCountryBriefPagedResultSortFilter
{
    public static IQueryable<CountryBriefDto> SortFilter(
        this IQueryable<CountryBriefDto> query,
        GetCountryBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.OrderCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<CountryBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

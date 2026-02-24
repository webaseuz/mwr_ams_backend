using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Citizenships;

public static class GetCitizenshipBriefPagedResultSortFilter
{
    public static IQueryable<CitizenshipBriefDto> SortFilter(
        this IQueryable<CitizenshipBriefDto> query,
        GetCitizenshipBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.WbCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<CitizenshipBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Nationalities;

public static class GetNationalityBriefPagedResultSortFilter
{
    public static IQueryable<NationalityBriefDto> SortFilter(
        this IQueryable<NationalityBriefDto> query,
        GetNationalityBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.WbCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<NationalityBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}
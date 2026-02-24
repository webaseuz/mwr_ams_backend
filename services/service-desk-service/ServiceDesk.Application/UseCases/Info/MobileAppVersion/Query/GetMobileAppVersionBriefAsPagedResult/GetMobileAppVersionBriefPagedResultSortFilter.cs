using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public static class GetMobileAppVersionBriefPagedResultSortFilter
{
    public static IQueryable<MobileAppVersionBriefDto> SortFilter(
        this IQueryable<MobileAppVersionBriefDto> query,
        GetMobileAppVersionBriefPagedResultQuery request)
    {

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.VersionCode.ToLower().Contains(target) ||
                                     a.FileName.ToLower().Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<MobileAppVersionBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}
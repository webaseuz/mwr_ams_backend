using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Branches;

public static class GetBranchBriefPagedResultSortFilter
{
    public static IQueryable<BranchBriefDto> SortFilter(
        this IQueryable<BranchBriefDto> query,
        GetBranchBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.UniqueCode.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<BranchBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}
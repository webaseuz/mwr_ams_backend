using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Roles;

public static class GetRoleBriefPagedResultSortFilter
{
    public static IQueryable<RoleBriefDto> SortFilter(
        this IQueryable<RoleBriefDto> query,
        GetRoleBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target));

        }

        if (request.HasSort() && request.IsValidSortBy<RoleBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

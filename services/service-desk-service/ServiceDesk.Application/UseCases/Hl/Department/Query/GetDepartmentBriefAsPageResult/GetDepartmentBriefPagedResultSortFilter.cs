using System.Linq.Dynamic.Core;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.Departments;

public static class GetDepartmentBriefPagedResultSortFilter
{
    public static IQueryable<DepartmentBriefDto> SortFilter(
        this IQueryable<DepartmentBriefDto> query,
        GetDepartmentBriefPagedResultQuery request)
    {
        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.ShortName.ToLower().Contains(target) ||
                                     a.FullName.ToLower().Contains(target) ||
                                     a.Code.Contains(target));
        }

        if (request.HasSort() && request.IsValidSortBy<DepartmentBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }           
}

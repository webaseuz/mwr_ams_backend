using AutoPark.Application.Security;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Departments;

public static class GetDepartmentBriefPagedResultSortFilter
{
    public static async Task<IQueryable<DepartmentBriefDto>> SortFilter(
        this IQueryable<DepartmentBriefDto> query,
        GetDepartmentBriefPagedResultQuery request,
        IAsyncAppAuthService authService)
    {
        if (!await authService.HasPermissionAsync(nameof(PermissionCode.DepartmentAllView)))
            request.BranchId = (await authService.GetUserAsync())?.BranchId;

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

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

using AutoPark.Application.Security;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Drivers;

public static class GetDriverBriefPagedResultSortFilter
{
    public static async Task<IQueryable<DriverBriefDto>> SortFilter(
        this IQueryable<DriverBriefDto> query,
        GetDriverBriefPagedResultQuery request, IAsyncAppAuthService appAuthService)
    {
        if (!await appAuthService.HasPermissionAsync(nameof(PermissionCode.BranchAllView)))
            request.BranchId = (await appAuthService.GetUserAsync()).BranchId;

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(a => a.PersonName.ToLower().Contains(target) ||
                                     a.BranchName.ToLower().Contains(target));

        }

        var userData = await appAuthService.GetUserAsync();

        if (!await appAuthService.HasPermissionAsync(nameof(PermissionCode.AllViewDriver)))
        {
            if (userData.BranchId.HasValue)
                query = query.Where(q => q.BranchId == userData.BranchId);
        }

        if (request.HasSort() && request.IsValidSortBy<DriverBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }
}

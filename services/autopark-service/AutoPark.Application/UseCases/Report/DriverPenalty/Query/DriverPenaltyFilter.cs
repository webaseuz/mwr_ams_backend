using AutoPark.Application.Security;
using Bms.WEBASE.Extensions;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.DriverPenalties;

public static class DriverPenaltyFilter
{
    public static IQueryable<DriverPenaltyBriefDto> FilterByUserInput(this IQueryable<DriverPenaltyBriefDto> query,
                                                                      GetDriverPenaltyBriefAsPagedResultQuery request)
    {
        request.Init();

        if (request.RegionId.HasValue)
            query = query.Where(q => q.RegionId == request.RegionId);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId);

        if (request.DriverId.HasValue)
            query = query.Where(q => q.DriverId == request.DriverId);

        if (request.TransportId.HasValue)
            query = query.Where(q => q.TransportId == request.TransportId);

        if (!request.RegistrationNumber.IsNullOrEmptyObject())
            query = query.Where(q => q.RegistrationNumber.Contains(request.RegistrationNumber, StringComparison.OrdinalIgnoreCase));

        query = query.Where(q => q.CreatedAt >= request.ExpireFromDate &&
                                 q.CreatedAt <= request.ExpireToDate);

        return query;
    }

    public static async Task<IQueryable<DriverPenaltyBriefDto>> FilterByPermissions(this IQueryable<DriverPenaltyBriefDto> query,
                                                                                    IAsyncAppAuthService authService)
    {
        var canViewPersonal = await authService.HasPermissionAsync(PermissionCode.DriverPenaltyView);
        var canViewBranch = await authService.HasPermissionAsync(PermissionCode.DriverPenaltyBranchView);
        var canViewAll = await authService.HasPermissionAsync(PermissionCode.DriverPenaltyAllView);

        if (canViewAll)
            return query;

        var userInfo = await authService.GetUserAsync();

        if (canViewBranch)
            return query.Where(q => q.BranchId == userInfo.BranchId);

        if (canViewPersonal)
            return query.Where(q => q.PersonId == userInfo.PersonId);

        return null;
    }
}

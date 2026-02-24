using AutoPark.Application.Security;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Refuels;

public static class RefuelBriefPageResultSortFilter
{
    public async static Task<IQueryable<RefuelBriefDto>> SortFilter(
        this IQueryable<RefuelBriefDto> query,
        GetRefuelBriefPageResultQuery request,
        IAsyncAppAuthService authService)
    {
        var userInfo = await authService.GetUserAsync();

        var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.RefuelViewAll));
        var hasBranchAll = userInfo.Permissions.Contains(nameof(PermissionCode.RefuelBranchView));

        if (!hasViewAll && hasBranchAll)
        {
            query = query.Where(x => x.StatusId != StatusIdConst.DELETED);
            request.BranchId = userInfo.BranchId;
        }
        else if (!hasViewAll && !hasBranchAll)
        {
            request.BranchId = userInfo.BranchId;
            query = query.Where(x => x.PersonId == userInfo.PersonId);
        }

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.DriverId.HasValue)
            query = query.Where(x => x.DriverId == request.DriverId);

        if (request.TransportId.HasValue)
            query = query.Where(x => x.TransportId == request.TransportId);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.DocNumber.ToLower().Contains(target) ||
                                     x.ChequeNumber.ToLower().Contains(target) ||
                                     x.BranchName.ToLower().Contains(target));
        }

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);
        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<RefuelBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

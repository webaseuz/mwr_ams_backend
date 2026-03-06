using System.Linq.Dynamic.Core;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Service.Adm.Models;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public static class RefuelBriefPageResultSortFilter
{
    public static Task<IQueryable<RefuelBriefDto>> SortFilter(
        this IQueryable<RefuelBriefDto> query,
        RefuelGetBriefPageResultQuery request,
        IMainAuthService authService)
    {
        var userInfo = authService.User;
        var hasViewAll = userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.RefuelViewAll));
        var hasBranchAll = userInfo.Permissions.Contains(nameof(AutoparkPermissionCode.RefuelBranchView));

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

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<RefuelBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return Task.FromResult(query);
    }
}

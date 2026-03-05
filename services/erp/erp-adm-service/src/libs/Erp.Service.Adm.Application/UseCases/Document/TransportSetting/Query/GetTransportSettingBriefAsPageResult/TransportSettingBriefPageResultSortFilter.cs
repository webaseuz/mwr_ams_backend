using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Service.Adm.Models;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public static class TransportSettingBriefPageResultSortFilter
{
    public static Task<IQueryable<TransportSettingBriefDto>> SortFilter(
        this IQueryable<TransportSettingBriefDto> query,
        TransportSettingGetBriefPageResultQuery request,
        IMainAuthService authService)
    {
        var userInfo = authService.User;
        var hasViewAll = userInfo.Permissions.Contains(nameof(AdmPermissionCode.TransportSettingViewAll));

        if (!hasViewAll)
            request.BranchId = userInfo.BranchId;

        query = query.Where(x => x.StatusId != StatusIdConst.DELETED);

        if (request.HasSearch())
        {
            string target = $"%{request.Search.ToLower()}%";
            query = query.Where(x => EF.Functions.Like(x.ManagerFullName.ToLower(), target) ||
                                     EF.Functions.Like(x.TransportName.ToLower(), target) ||
                                     EF.Functions.Like(x.DriverName.ToLower(), target) ||
                                     EF.Functions.Like(x.TransportModelName.ToLower(), target) ||
                                     EF.Functions.Like(x.DocNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.LicenseNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.PoaNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.FuelCardNumber.ToLower(), target) ||
                                     EF.Functions.Like(x.ResponsiblePersonName.ToLower(), target) ||
                                     EF.Functions.Like(x.StatusName.ToLower(), target));
        }

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.DriverId.HasValue)
            query = query.Where(x => x.DriverId == request.DriverId);

        if (request.HasSort() && request.IsValidSortBy<TransportSettingBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return Task.FromResult(query);
    }
}

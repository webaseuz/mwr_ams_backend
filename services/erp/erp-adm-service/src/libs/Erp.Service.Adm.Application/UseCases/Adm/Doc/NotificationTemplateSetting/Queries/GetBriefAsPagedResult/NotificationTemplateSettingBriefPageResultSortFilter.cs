using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using System.Linq.Dynamic.Core;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public static class NotificationTemplateSettingBriefPageResultSortFilter
{
    public static IQueryable<NotificationTemplateSettingBriefDto> SortFilter(
        this IQueryable<NotificationTemplateSettingBriefDto> query,
        GetNotificationTemplateSettingBriefPageResultQuery request,
        IMainAuthService authService)
    {
        var userInfo = authService.User;

        var hasViewAll = userInfo.Permissions.Contains(nameof(AdmPermissionCode.AllNotificationTemplateSettingView));
        if (!hasViewAll)
        {
            query = query.Where(x => x.StatusId != StatusIdConst.DELETED);
            request.BranchId = userInfo.BranchId;
        }

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();
            query = query.Where(x => x.DocNumber.ToLower().Contains(target) ||
                                     x.BranchName.ToLower().Contains(target));
        }

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<NotificationTemplateSettingBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.Notifications;

public static class GetNotificationsByUserQuerySortFilter
{
    public async static Task<IQueryable<NotificationBriefDto>> SortFilter(
        this IQueryable<NotificationBriefDto> query,
        GetNotificationsByUserQuery request,
        IAsyncAppAuthService authService)
    {
        var userInfo = await authService.GetUserAsync();

        var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.AllNotificationView));

        if (!hasViewAll)
        {
            query = query.Where(x => x.StateId == StateIdConst.ACTIVE);
        }

        query = query.Where(x => x.UserId == userInfo.Id);

        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.Subject.ToLower().Contains(target));
        }

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<NotificationBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

using AutoPark.Application.Security;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.PresentNotifications;

public static class PresentNotificationBriefPageResultSortFilter
{
    public async static Task<IQueryable<PresentNotificationBriefDto>> SortFilter(
        this IQueryable<PresentNotificationBriefDto> query,
        GetPresentNotificationBriefPageResultQuery request,
        IAsyncAppAuthService authService)
    {
        var userInfo = await authService.GetUserAsync();

        var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.AllPresentNotificationView));

        if (request.UserId.HasValue)
            query = query.Where(x => x.UserId == request.UserId);


        if (request.HasSearch())
        {
            string target = request.Search.ToLower();

            query = query.Where(x => x.Subject.ToLower().Contains(target));
        }

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSort() && request.IsValidSortBy<PresentNotificationBriefDto>())
            query = query.OrderBy($"{request.SortBy} {request.OrderType}");
        else
            query = query.OrderByDescending(x => x.Id);

        return query;
    }
}

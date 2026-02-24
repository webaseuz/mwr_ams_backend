using ServiceDesk.Application.Security;
using ServiceDesk.Domain.Constants;
using Bms.Core.Application;
using System.Linq.Dynamic.Core;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public static class NotificationTemplateSettingBriefPageResultSortFilter
{
	public async static Task<IQueryable<NotificationTemplateSettingBriefDto>> SortFilter(
		this IQueryable<NotificationTemplateSettingBriefDto> query,
		GetNotificationTemplateSettingBriefPageResultQuery request,
		IAsyncAppAuthService authService)
	{

		var userInfo = await authService.GetUserAsync();

		var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.AllNotificationTemplateSettingView));
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

		if (request.BranchId.HasValue)
			query = query.Where(x => x.BranchId == request.BranchId.Value);
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

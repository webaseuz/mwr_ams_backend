using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetNotificationTemplateSettingBriefPageResultHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ICultureHelper cultureHelper) : IRequestHandler<GetNotificationTemplateSettingBriefPageResultQuery, WbPagedResult<NotificationTemplateSettingBriefDto>>
{
    public async Task<WbPagedResult<NotificationTemplateSettingBriefDto>> Handle(
        GetNotificationTemplateSettingBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.NotificationTemplateSettings.AsQueryable().MapTo<NotificationTemplateSettingBriefDto>(mapper, cultureHelper);

        query = query.SortFilter(request, authService);

        var result = await query.AsPagedResultAsync(request);

        result.Rows = await result.Rows.SetActionControls(authService);

        return result;
    }
}

public static class NotificationTemplateSettingBriefDtoExtension
{
    public static Task<IEnumerable<NotificationTemplateSettingBriefDto>> SetActionControls(
        this IEnumerable<NotificationTemplateSettingBriefDto> query,
        IMainAuthService authService)
    {
        foreach (var item in query)
        {
            item.CanAccept = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.ACCEPTED) &&
                             authService.HasPermission(nameof(AdmPermissionCode.NotificationTemplateSettingAccept));
            item.CanCancel = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.CANCELLED) &&
                             authService.HasPermission(nameof(AdmPermissionCode.NotificationTemplateSettingCancel));
            item.CanDelete = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.DELETED) &&
                             authService.HasPermission(nameof(AdmPermissionCode.NotificationTemplateSettingDelete));
            item.CanModify = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.MODIFIED) &&
                             authService.HasPermission(nameof(AdmPermissionCode.NotificationTemplateSettingEdit));
        }
        return Task.FromResult(query);
    }
}
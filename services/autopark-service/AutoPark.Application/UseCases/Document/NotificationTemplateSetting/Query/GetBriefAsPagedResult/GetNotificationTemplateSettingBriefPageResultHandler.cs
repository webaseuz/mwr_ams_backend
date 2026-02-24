using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingBriefPageResultHandler :
    IRequestHandler<GetNotificationTemplateSettingBriefPageResultQuery, PagedResultWithActionControls<NotificationTemplateSettingBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetNotificationTemplateSettingBriefPageResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<NotificationTemplateSettingBriefDto>> Handle(
        GetNotificationTemplateSettingBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<NotificationTemplateSetting, NotificationTemplateSettingBriefDto>(_context.NotificationTemplateSettings);

        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.NotificationTemplateSettingCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);
        return result;
    }
}

public static class NotificationTemplateSettingBriefDtoExtension
{
    public static async Task<IEnumerable<NotificationTemplateSettingBriefDto>> SetActionControls(
        this IEnumerable<NotificationTemplateSettingBriefDto> query,
        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var item in query)
        {
            item.CanAccept = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.ACCEPTED) &&
                             permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingAccept));
            item.CanCancel = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.CANCELLED) &&
                             permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingCancel));
            item.CanDelete = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.DELETED) &&
                             permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingDelete));
            item.CanModify = StatusIdConst.CanNotificationTemplateSettingStatus(item.StatusId, StatusIdConst.MODIFIED) &&
                             permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingEdit));
        }
        return query;
    }
}
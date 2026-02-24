using AutoPark.Application.Security;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingQueryHandler :
    IRequestHandler<GetNotificationTemplateSettingQuery, NotificationTemplateSettingDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetNotificationTemplateSettingQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<NotificationTemplateSettingDto> Handle(
        GetNotificationTemplateSettingQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserAsync();

        var result = new NotificationTemplateSettingDto()
        {
            DocDate = DateTime.Today,
            CanCreateForAllBranch = user.Permissions.Contains(nameof(PermissionCode.AllNotificationTemplateSettingView)),
            BranchId = user.BranchId
        };

        return result;
    }
}

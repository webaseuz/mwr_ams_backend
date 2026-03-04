using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetNotificationTemplateSettingQueryHandler(
    IMainAuthService authService) : IRequestHandler<GetNotificationTemplateSettingQuery, NotificationTemplateSettingDto>
{
    public Task<NotificationTemplateSettingDto> Handle(GetNotificationTemplateSettingQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        var result = new NotificationTemplateSettingDto
        {
            DocDate = DateTime.Today,
            CanCreateForAllBranch = authService.HasPermission(nameof(PermissionCode.AllNotificationTemplateSettingView)),
            BranchId = userInfo.BranchId
        };

        return Task.FromResult(result);
    }
}

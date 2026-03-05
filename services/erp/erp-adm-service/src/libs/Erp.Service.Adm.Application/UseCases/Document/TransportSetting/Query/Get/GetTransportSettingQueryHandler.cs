using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportSettingQueryHandler(
    IMainAuthService authService) : IRequestHandler<TransportSettingGetQuery, TransportSettingDto>
{
    public Task<TransportSettingDto> Handle(TransportSettingGetQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;
        var dto = new TransportSettingDto
        {
            DocDate = DateTime.Today,
            BranchId = userInfo.BranchId ?? 0,
            CanCreateForAllBranch = authService.HasPermission(nameof(AdmPermissionCode.TransportSettingViewAll))
        };
        return Task.FromResult(dto);
    }
}

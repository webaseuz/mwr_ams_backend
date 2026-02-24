using AutoPark.Application.Security;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingQueryHandler :
    IRequestHandler<GetTransportSettingQuery, TransportSettingDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetTransportSettingQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<TransportSettingDto> Handle(
        GetTransportSettingQuery request,
        CancellationToken cancellationToken)
    {
        var userInfo = await _authService.GetUserAsync();

        var dto = new TransportSettingDto();
        dto.BranchId = userInfo.BranchId.Value;
        dto.DocDate = DateTime.Today;

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.TransportSettingViewAll));

        return dto;
    }
}

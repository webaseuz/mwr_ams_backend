using AutoPark.Application.Security;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverQueryHandler :
    IRequestHandler<GetDriverQuery, DriverDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetDriverQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<DriverDto> Handle(
        GetDriverQuery request,
        CancellationToken cancellationToken)
    {
        var dto = new DriverDto();
        var userInfo = await _authService.GetUserAsync();

        dto.BranchId = userInfo.BranchId.Value;
        dto.CanCreateForAllBranch = userInfo.Permissions.Contains(nameof(PermissionCode.AllViewDriver));

        return dto;
    }
}

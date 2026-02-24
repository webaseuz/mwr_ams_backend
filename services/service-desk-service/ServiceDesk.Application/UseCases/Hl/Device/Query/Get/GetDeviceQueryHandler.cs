using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceQueryHandler :
    IRequestHandler<GetDeviceQuery, DeviceDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetDeviceQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }

    public async Task<DeviceDto> Handle(
        GetDeviceQuery request,
        CancellationToken cancellationToken)
    {
        var result = new DeviceDto();

        var user = await _authService.GetUserAsync();

        result.CanCreateForAllBranch = user.Permissions.Contains(nameof(PermissionCode.DeviceViewAll));

         return result;
    } }

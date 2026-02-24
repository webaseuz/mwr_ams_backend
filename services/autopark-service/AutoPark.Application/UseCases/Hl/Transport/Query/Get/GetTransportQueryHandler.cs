using AutoPark.Application.Security;
using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportQueryHandler :
    IRequestHandler<GetTransportQuery, TransportDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetTransportQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<TransportDto> Handle(
        GetTransportQuery request,
        CancellationToken cancellationToken)
    {

        var dto = new TransportDto();

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.AllViewTransport));

        return dto;
    }
}

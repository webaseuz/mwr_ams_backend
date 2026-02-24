using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementQueryHandler :
    IRequestHandler<GetSpareMovementQuery, SpareMovementDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetSpareMovementQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }
    public async Task<SpareMovementDto> Handle(
        GetSpareMovementQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserAsync();

        var result = new SpareMovementDto()
        {
            DocDate = DateTime.Today,
            CanCreateForAllBranch = user.Permissions.Contains(nameof(PermissionCode.SpareMovementAllView))
        };
        return result;
    }
}

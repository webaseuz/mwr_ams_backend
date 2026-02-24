using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationQueryHandler :
    IRequestHandler<GetServiceApplicationQuery, ServiceApplicationDto>
{
    private readonly IAsyncAppAuthService _authService;

    public GetServiceApplicationQueryHandler(IAsyncAppAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ServiceApplicationDto> Handle(
        GetServiceApplicationQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _authService.GetUserAsync();

        var result = new ServiceApplicationDto()
        {
            DocDate = DateTime.Today,
            BranchId = user.BranchId.Value,
            CanCreateForAllBranch = user.Permissions.Contains(nameof(PermissionCode.AllViewServiceApplication)),
            CanEditExecutor = false    
        };

        return result;
    }

}

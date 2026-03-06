using Erp.Core;
using Erp.Core.Constants;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetRefuelQueryHandler(IMainAuthService authService) : IRequestHandler<RefuelGetQuery, RefuelDto>
{
    public Task<RefuelDto> Handle(RefuelGetQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;
        var dto = new RefuelDto
        {
            DocDate = DateTime.Today,
            BranchId = userInfo.BranchId,
            CanCreateForAllBranch = authService.HasPermission(nameof(AdmPermissionCode.RefuelViewAll))
        };
        return Task.FromResult(dto);
    }
}

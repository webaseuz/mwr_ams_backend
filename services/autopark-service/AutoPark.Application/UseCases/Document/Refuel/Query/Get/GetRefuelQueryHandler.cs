using AutoPark.Application.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelQueryHandler :
    IRequestHandler<GetRefuelQuery, RefuelDto>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    public GetRefuelQueryHandler(IAsyncAppAuthService authService, IReadEfCoreContext context)
    {
        _authService = authService;
        _context = context;
    }
    public async Task<RefuelDto> Handle(
        GetRefuelQuery request,
        CancellationToken cancellationToken)
    {
        var userInfo = await _authService.GetUserAsync();
        var dto = new RefuelDto();
        dto.DocDate = DateTime.Today;
        dto.BranchId = userInfo.BranchId;

        var branch = await _context.Branches.AsQueryable().Where(b => b.Id == dto.BranchId).FirstOrDefaultAsync();

        dto.BranchName = branch.FullName;

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.RefuelViewAll));

        return dto;
    }
}

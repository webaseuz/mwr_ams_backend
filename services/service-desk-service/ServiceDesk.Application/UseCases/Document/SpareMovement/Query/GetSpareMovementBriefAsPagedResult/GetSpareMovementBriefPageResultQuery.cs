using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<SpareMovementBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }

    public async Task InitAsync(IAsyncAppAuthService authService)
    {
        var user = await authService.GetUserAsync();

        if (!user.Permissions.Contains(nameof(PermissionCode.SpareMovementAllView)))
            BranchId = user.BranchId;

        if (!FromDate.HasValue)
            FromDate = new DateTime(DateTime.Now.Year,1, 1);

        if (!ToDate.HasValue)
            ToDate = DateTime.Today;
    }
}

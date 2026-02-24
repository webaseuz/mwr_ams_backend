using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class GetUserBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<UserBriefDto>>
{
    public int? RegionId { get; set; }
    public int? DistrictId { get; set; }
    public int? BranchId { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public int? StateId { get; set; }

    public async Task Init(IAsyncAppAuthService asyncAppAuthService)
    {
        var userData = await asyncAppAuthService.GetUserAsync();

        if (!userData.Permissions.Contains(nameof(PermissionCode.AllUserView)))
        {
            BranchId = userData.BranchId;
            StateId = StateIdConst.ACTIVE;
        }

        if (RegionId <= 0)
            RegionId = null;
        if (DistrictId <= 0)
            DistrictId = null;
        if (BranchId <= 0)
            BranchId = null;
        if (StateId <= 0)
            StateId = null;
    }
}

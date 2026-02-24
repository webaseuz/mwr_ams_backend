using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingBriefAsPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<TransportSettingBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }

    public async Task Init(IAsyncAppAuthService asyncAppAuthService)
    {
        var userData = await asyncAppAuthService.GetUserAsync();

        if (!await asyncAppAuthService.HasPermissionAsync(nameof(PermissionCode.TransportSettingViewAll)))
        {
            if (!await asyncAppAuthService.HasPermissionAsync(nameof(PermissionCode.TransportSettingViewByBranch)))
            {
                BranchId = userData?.BranchId;
            }
            else if (await asyncAppAuthService.HasPermissionAsync(nameof(PermissionCode.TransportSettingViewByDriver)))
            {
                DriverId = userData.Id;
            }
        }
    }
}

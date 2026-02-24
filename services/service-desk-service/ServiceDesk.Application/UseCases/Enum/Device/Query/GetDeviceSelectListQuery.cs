using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceSelectListQuery :
    IRequest<SelectList<int>>
{ 
    public int? BranchId { get; set; }
    public int? DeviceTypeId { get; set; }
    public async Task Init(IAsyncAppAuthService authService)
    {
        var userInfo = await authService.GetUserAsync();

        var permissions = userInfo.Permissions;

        if (!permissions.Contains(nameof(PermissionCode.DeviceViewAll)))
            BranchId = userInfo.BranchId;

        if (DeviceTypeId.IsNullOrEmptyObject())
            DeviceTypeId = null;
    
    }
}

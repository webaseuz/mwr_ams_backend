using AutoPark.Application.Security;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardSelectListQuery : IRequest<SelectList<int>>
{
    public int? DriverId { get; set; }
    public int? TransportId { get; set; }
    public int? CardTypeId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportSettingId { get; set; }

    public async Task Init(IAsyncAppAuthService authService)
    {
        var userData = await authService.GetUserAsync();

        if (!userData.Permissions.Contains(nameof(PermissionCode.FuelCardViewAll)))
            BranchId = userData?.BranchId;

        if (TransportSettingId.HasValue)
        {
            TransportId = null;
            DriverId = null;
        }
    }
}

using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class CreateFuelCardCommand :
    IRequest<IHaveId<int>>
{
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; } = null!;
    public string ExpireAt { get; set; }
}

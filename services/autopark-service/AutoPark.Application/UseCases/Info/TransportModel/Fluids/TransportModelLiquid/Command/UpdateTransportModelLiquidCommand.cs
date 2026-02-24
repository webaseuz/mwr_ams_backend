using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelLiquidCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
}

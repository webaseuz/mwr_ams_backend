using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelLiquidCommand :
        IRequest<IHaveId<int>>
{
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
}

using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelFuelCommand :
        IRequest<IHaveId<int>>
{
    public int FuelTypeId { get; set; }
    public decimal TankVolume { get; set; }
}

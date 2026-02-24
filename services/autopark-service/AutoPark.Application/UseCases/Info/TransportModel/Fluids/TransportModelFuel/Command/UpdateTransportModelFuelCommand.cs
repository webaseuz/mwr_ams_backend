using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelFuelCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public int FuelTypeId { get; set; }
    public decimal TankVolume { get; set; }
}

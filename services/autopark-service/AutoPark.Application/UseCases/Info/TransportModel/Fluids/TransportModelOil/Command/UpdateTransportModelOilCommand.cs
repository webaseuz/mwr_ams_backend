using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class UpdateTransportModelOilCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public int OilTypeId { get; set; }
    public int? OilModelId { get; set; }
    public decimal TankVolume { get; set; }
}

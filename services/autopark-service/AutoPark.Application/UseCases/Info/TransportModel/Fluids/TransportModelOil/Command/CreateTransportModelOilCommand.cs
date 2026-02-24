using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelOilCommand :
        IRequest<IHaveId<int>>
{
    public int OilTypeId { get; set; }
    public int? OilModelId { get; set; }
    public decimal TankVolume { get; set; }
}

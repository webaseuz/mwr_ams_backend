using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingOilCommand :
    IRequest<IHaveId<long>>
{
    public int OilTypeId { get; set; }
    //public int OilModelId { get; set; }
    //public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}

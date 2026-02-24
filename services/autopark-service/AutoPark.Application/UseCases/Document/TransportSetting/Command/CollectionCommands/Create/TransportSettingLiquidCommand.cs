using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingLiquidCommand :
    IRequest<IHaveId<long>>
{
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}

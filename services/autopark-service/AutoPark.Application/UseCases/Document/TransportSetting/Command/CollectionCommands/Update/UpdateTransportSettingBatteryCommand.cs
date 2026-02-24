using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingBatteryCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}

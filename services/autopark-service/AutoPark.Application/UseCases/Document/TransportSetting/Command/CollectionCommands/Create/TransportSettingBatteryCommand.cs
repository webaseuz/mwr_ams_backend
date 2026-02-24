using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingBatteryCommand
    : IRequest<IHaveId<long>>
{
    public int Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}

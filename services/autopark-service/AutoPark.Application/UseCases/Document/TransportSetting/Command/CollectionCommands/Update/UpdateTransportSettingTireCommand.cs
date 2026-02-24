using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingTireCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int TireSizeId { get; set; }
    public int? TireModelId { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}

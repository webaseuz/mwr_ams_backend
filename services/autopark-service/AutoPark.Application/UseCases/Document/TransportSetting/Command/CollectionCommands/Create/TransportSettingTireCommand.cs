using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingTireCommand :
    IRequest<IHaveId<long>>
{
    public int Quantity { get; set; }
    public int TireSizeId { get; set; }
    public int? TireModelId { get; set; }
    public string Size { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}

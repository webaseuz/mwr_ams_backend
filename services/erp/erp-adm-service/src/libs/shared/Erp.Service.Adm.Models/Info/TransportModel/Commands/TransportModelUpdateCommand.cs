using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportModelUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int TransportTypeId { get; set; }
    public int TransportBrandId { get; set; }
    public int TransmissionBoxTypeId { get; set; }
    public decimal? LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal ConsumptionPer100Km { get; set; }
    public decimal ConsumptionPerHour { get; set; }
    public List<TransportModelTranslateCreateUpdateCommand> Translates { get; set; } = new();
    public List<TransportModelFuelCreateUpdateCommand> Fuels { get; set; } = new();
    public List<TransportModelLiquidCreateUpdateCommand> Liquids { get; set; } = new();
    public List<TransportModelOilCreateUpdateCommand> Oils { get; set; } = new();
    public List<TransportModelFileCreateUpdateCommand> Files { get; set; } = new();
}

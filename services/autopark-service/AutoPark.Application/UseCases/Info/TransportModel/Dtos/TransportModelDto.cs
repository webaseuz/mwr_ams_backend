using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int TransportTypeId { get; set; }
    public string TransportTypeName { get; set; }
    public int TransportBrandId { get; set; }
    public string TransportBrandName { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public int TransmissionBoxTypeId { get; set; }
    public string TransmissionBoxTypeName { get; set; }
    public decimal? LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal ConsumptionPer100Km { get; set; }
    public decimal ConsumptionPerHour { get; set; }
    public List<TransportModelFileDto> Files { get; set; } = new();
    public List<TransportModelLiquidDto> Liquids { get; set; } = new();
    public List<TransportModelFuelDto> Fuels { get; set; } = new();
    public List<TransportModelOilDto> Oils { get; set; } = new();

    public List<TransportModelTranslateDto> Translates { get; set; } = new();
}

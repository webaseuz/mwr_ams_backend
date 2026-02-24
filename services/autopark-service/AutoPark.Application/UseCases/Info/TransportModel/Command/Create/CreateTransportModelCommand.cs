using Bms.WEBASE.Models;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelCommand :
    IRequest<IHaveId<int>>
{
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
    public List<TransportModelTranslateCommand> Translates { get; set; } = new();
    public List<CreateTransportModelLiquidCommand> Liquids { get; set; } = new();
    public List<CreateTransportModelFuelCommand> Fuels { get; set; } = new();
    public List<CreateTransportModelOilCommand> Oils { get; set; } = new();
    public List<CreateTransportModelFileCommand> Files { get; set; } = new();
}

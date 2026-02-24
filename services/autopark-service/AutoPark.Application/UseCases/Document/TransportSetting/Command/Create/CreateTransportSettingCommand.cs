using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingCommand
    : IRequest<IHaveId<long>>
{
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public int OrganizationId { get; set; }
    public long? ManagerId { get; set; }
    public string LicenseNumber { get; set; } = null!;
    public DateTime LicenseEndAt { get; set; }
    public string PoaNumber { get; set; } = null!;
    public DateTime PoaEndAt { get; set; }
    public string ManagerFullName { get; set; }
    //public decimal LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Message { get; set; }
    public int WorkedHours { get; set; }
    public List<CreateTransportSettingBatteryCommand> Batteries { get; set; } = new();
    public List<CreateTransportSettingFuelCommand> Fuels { get; set; } = new();
    public List<CreateTransportSettingInspectionCommand> Inspections { get; set; } = new();
    public List<CreateTransportSettingInsuranceCommand> Insurances { get; set; } = new();
    public List<CreateTransportSettingLiquidCommand> Liquids { get; set; } = new();
    public List<CreateTransportSettingOilCommand> Oils { get; set; } = new();
    public List<CreateTransportSettingTireCommand> Tires { get; set; } = new();
    public List<CreateTransportSettingFileCommand> Files { get; set; } = new();
}

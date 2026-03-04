using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportSettingCreateCommand : IRequest<WbHaveId<long>>
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
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Message { get; set; }
    public int WorkedHours { get; set; }
    public List<TransportSettingBatteryCreateCommand> Batteries { get; set; } = new();
    public List<TransportSettingFuelCreateCommand> Fuels { get; set; } = new();
    public List<TransportSettingInspectionCreateCommand> Inspections { get; set; } = new();
    public List<TransportSettingInsuranceCreateCommand> Insurances { get; set; } = new();
    public List<TransportSettingLiquidCreateCommand> Liquids { get; set; } = new();
    public List<TransportSettingOilCreateCommand> Oils { get; set; } = new();
    public List<TransportSettingTireCreateCommand> Tires { get; set; } = new();
    public List<TransportSettingFileDto> Files { get; set; } = new();
}

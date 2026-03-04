using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportSettingUpdateCommand : IRequest<WbHaveId<long>>
{
    public long Id { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public int OrganizationId { get; set; }
    public long? ManagerId { get; set; }
    public string LicenseNumber { get; set; }
    public DateTime LicenseEndAt { get; set; }
    public string PoaNumber { get; set; }
    public DateTime PoaEndAt { get; set; }
    public string ManagerFullName { get; set; }
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Message { get; set; }
    public int WorkedHours { get; set; }
    public List<TransportSettingBatteryUpdateCommand> Batteries { get; set; } = new();
    public List<TransportSettingFuelUpdateCommand> Fuels { get; set; } = new();
    public List<TransportSettingInspectionUpdateCommand> Inspections { get; set; } = new();
    public List<TransportSettingInsuranceUpdateCommand> Insurances { get; set; } = new();
    public List<TransportSettingLiquidUpdateCommand> Liquids { get; set; } = new();
    public List<TransportSettingOilUpdateCommand> Oils { get; set; } = new();
    public List<TransportSettingTireUpdateCommand> Tires { get; set; } = new();
    public List<TransportSettingFileDto> Files { get; set; } = new();
}

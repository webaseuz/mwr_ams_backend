using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int OrganizationId { get; set; }
    public int? BranchId { get; set; }
    public long? ManagerId { get; set; }
    public string LicenseNumber { get; set; }
    public DateTime LicenseEndAt { get; set; }
    public string PoaNumber { get; set; }
    public DateTime PoaEndAt { get; set; }
    public string ManagerFullName { get; set; }
    //public decimal LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Message { get; set; }
    public int WorkedHours { get; set; }
    public List<UpdateTransportSettingBatteryCommand> Batteries { get; set; } = new();
    public List<UpdateTransportSettingFuelCommand> Fuels { get; set; } = new();
    public List<UpdateTransportSettingInspectionCommand> Inspections { get; set; } = new();
    public List<UpdateTransportSettingInsuranceCommand> Insurances { get; set; } = new();
    public List<UpdateTransportSettingLiquidCommand> Liquids { get; set; } = new();
    public List<UpdateTransportSettingOilCommand> Oils { get; set; } = new();
    public List<UpdateTransportSettingTireCommand> Tires { get; set; } = new();
    public List<UpdateTransportSettingFileCommand> Files { get; set; } = new();
}

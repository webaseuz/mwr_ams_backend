using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingBriefDto
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public long? ManagerId { get; set; }
    public int BranchId { get; set; }
    public int OrganizationId { get; set; }
    public string BranchName { get; set; }
    public string TransportName { get; set; }
    public string TransportModelName { get; set; }
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public string LicenseNumber { get; set; } = null!;
    public DateTime LicenseEndAt { get; set; }
    public string PoaNumber { get; set; } = null!;
    public DateTime PoaEndAt { get; set; }
    public string ManagerFullName { get; set; }
    public decimal LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public string FuelCardNumber { get; set; } = null!;
    public long ResponsiblePersonId { get; set; }
    public string ResponsiblePersonName { get; set; }
    public string Message { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }

    public bool CanModify { get; set; }
    public bool CanAccept { get; set; }
    public bool CanDelete { get; set; }
    public bool CanCancel { get; set; }
}

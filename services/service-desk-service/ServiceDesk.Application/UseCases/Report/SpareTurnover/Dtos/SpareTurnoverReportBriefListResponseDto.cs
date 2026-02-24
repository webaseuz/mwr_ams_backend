using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverReportBriefListResponseDto
{
    public int? BeginQuantity { get; set; }
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime? FromDate { get; set; }
    public int? EndQuantity { get; set; }
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime? EndDate { get; set; }
    public string DeviceSpareTypeName { get; set; }
    public int? DeviceSpareTypeId { get; set; }
    public string Nomenclature { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
}

using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverReportBriefListDto
{
    [JsonProperty("begin_quantity")]
    public int? BeginQuantity { get; set; }
    [JsonProperty("from_date")]
    public DateTime? FromDate { get; set; }
    [JsonProperty("end_quantity")]
    public int? EndQuantity { get; set; }
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
    [JsonProperty("device_spare_type_name")]
    public string DeviceSpareTypeName { get; set; }
    [JsonProperty("device_spare_type_id")]
    public int? DeviceSpareTypeId { get; set; }
    [JsonProperty("nomenclature")]
    public string Nomenclature { get; set; }
    [JsonProperty("branch_id")]
    public int? BranchId { get; set; }
    [JsonProperty("branch_name")]
    public string BranchName { get; set; }
}

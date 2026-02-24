using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverBriefListDto
{
    [JsonProperty("branch_name")]
    public string BranchName { get; set; }
    [JsonProperty("nomenclature")]
    public string Nomenclature { get; set; }
    [JsonProperty("device_spare_type_name")]
    public string DeviceSpareTypeName { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    [JsonProperty("is_debit")]
    public bool IsDebit { get; set; }
    [JsonProperty("created_at")]
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime? CreatedAt { get; set; }
}

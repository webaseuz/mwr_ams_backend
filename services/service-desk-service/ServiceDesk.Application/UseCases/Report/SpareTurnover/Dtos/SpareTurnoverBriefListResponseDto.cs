using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverBriefListResponseDto
{
    public string BranchName { get; set; }
    public string Nomenclature { get; set; }
    public string DeviceSpareTypeName { get; set; }
    public int Quantity { get; set; }
    public bool IsDebit { get; set; }
    [JsonConverter(typeof(WbDateConverter))]
    public DateTime? CreatedAt { get; set; }
}

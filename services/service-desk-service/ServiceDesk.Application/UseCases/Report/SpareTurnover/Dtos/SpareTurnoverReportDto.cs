using Newtonsoft.Json;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

public class SpareTurnoverReportDto<TResult>
{
    [JsonProperty("page_index")]
    public int Page { get; set; }
    [JsonProperty("page_size")]
    public int PageSize { get; set; }
    [JsonProperty("total")]
    public int Total { get; set; }
    public List<TResult> Items { get; set; } = new();
}

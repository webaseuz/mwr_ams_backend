using Newtonsoft.Json;
namespace Ihma.Core.PrivateSdk.Models;

public class ErrorModelState
{
    [JsonProperty("errors")]
    public Dictionary<string, List<string>> Errors { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("status")]
    public int Status { get; set; }
    [JsonProperty("traceId")]
    public string TraceId { get; set; }
}

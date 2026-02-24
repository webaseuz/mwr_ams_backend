using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverCategoryModel
{
    [JsonProperty("PCATEGORY")]
    public string Category { get; set; }

    [JsonProperty("PBEGIN")]
    public string BeginDate { get; set; }

    [JsonProperty("PEND")]
    public string EndDate { get; set; }

    [JsonProperty("PCOMMENT")]
    public string Comment { get; set; }
}

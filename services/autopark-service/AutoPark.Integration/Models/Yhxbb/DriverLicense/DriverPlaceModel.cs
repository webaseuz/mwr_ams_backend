using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverPlaceModel
{
    [JsonProperty("PREGIONID")]
    public int RegionId { get; set; }

    [JsonProperty("PCITYID")]
    public int CityId { get; set; }

    [JsonProperty("PPLACE")]
    public string Place { get; set; }
}
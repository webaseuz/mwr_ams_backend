using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleSearchByPinfl
{

    [JsonProperty("Pinpp")]
    public string Pinfl { get; set; }
}

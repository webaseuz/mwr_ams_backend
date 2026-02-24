using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleSearchByPlateNumber
{
    [JsonProperty("pPlateNumber")]
    public string PlateNumber { get; set; }
}

using Newtonsoft.Json;

namespace Erp.Integration.Models;

public class VehicleSearchByPlateNumber
{
    [JsonProperty("pPlateNumber")]
    public string PlateNumber { get; set; }
}

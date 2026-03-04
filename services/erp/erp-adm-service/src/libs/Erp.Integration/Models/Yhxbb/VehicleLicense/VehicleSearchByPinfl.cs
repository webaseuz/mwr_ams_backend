using Newtonsoft.Json;

namespace Erp.Integration.Models;

public class VehicleSearchByPinfl
{

    [JsonProperty("Pinpp")]
    public string Pinfl { get; set; }
}

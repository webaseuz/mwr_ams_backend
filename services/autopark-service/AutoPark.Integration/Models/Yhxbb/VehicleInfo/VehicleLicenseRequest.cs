using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleLicenseRequest
{
    public VehicleLicenseRequest()
    {
        RequestId = Guid.NewGuid().ToString();
    }

    [JsonProperty("pRequestID")]
    public string RequestId { get; set; }

    [JsonProperty("pTexpassportSery")]
    public string TexPassportSery { get; set; }

    [JsonProperty("pTexpassportNumber")]
    public string TexPassportNumber { get; set; }

    [JsonProperty("pPlateNumber")]
    public string PlateNumber { get; set; }
}

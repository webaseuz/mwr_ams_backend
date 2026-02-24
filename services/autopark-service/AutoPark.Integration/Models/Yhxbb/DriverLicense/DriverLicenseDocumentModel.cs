using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverLicenseDocumentModel
{
    [JsonProperty("PBEGIN")]
    public DateTime BeginDate { get; set; }

    [JsonProperty("PEND")]
    public DateTime EndDate { get; set; }

    [JsonProperty("PISSUEDBY")]
    public int? IssuedBy { get; set; }

    [JsonProperty("PSERIALNUMBER")]
    public string SerialNumber { get; set; }
}
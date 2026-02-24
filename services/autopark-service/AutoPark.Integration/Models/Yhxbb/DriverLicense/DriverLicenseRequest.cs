using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverLicenseRequest
{
    public DriverLicenseRequest()
    {
        RequestId = Guid.NewGuid().ToString();
    }

    [JsonProperty("pRequestID")]
    public string RequestId { get; set; }

    [JsonProperty("pSery")]
    public string PassportSeries { get; set; }

    [JsonProperty("pNumber")]
    public string PassportNumber { get; set; }

    [JsonProperty("applicantPinpp")]
    public string ApplicantPinfl { get; set; }
}
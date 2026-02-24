using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleInfoResponse
{
    [JsonProperty("PRESULT")]
    public int Result { get; set; }

    [JsonProperty("PCOMMENT")]
    public string Comment { get; set; }

    [JsonProperty("PPINPP")]
    public string Pinfl { get; set; }

    [JsonProperty("POWNER")]
    public string OwnerName { get; set; }

    [JsonProperty("POWNERTYPE")]
    public int OwnerType { get; set; }

    [JsonProperty("PORGANIZATIONINN")]
    public string OrganizationInn { get; set; }

    [JsonProperty("VEHICLE")]
    public List<VehicleInfoModel> Vehicles { get; set; }
}

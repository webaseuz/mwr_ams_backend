using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverLicenseResponse
{
    [JsonProperty("PRESULT")]
    public int Result { get; set; }

    [JsonProperty("PCOMMENT")]
    public string Comment { get; set; }

    [JsonProperty("PPINPP")]
    public string Pinfl { get; set; }

    [JsonProperty("PDOC")]
    public string DriverDocument { get; set; }

    [JsonProperty("POWNER")]
    public string DriverFullName { get; set; }

    [JsonProperty("POWNER_DATE")]
    public DateTime DriverBirthOn { get; set; }

    [JsonProperty("PBEGIN")]
    public DateTime DocumentStartDate { get; set; }

    [JsonProperty("PEND")]
    public DateTime DocumentEndDate { get; set; }

    [JsonProperty("MODELDL")]
    public DriverLicenseDocumentModel DocumentInfo { get; set; }

    [JsonProperty("DRIVERBIRTHPLACE")]
    public DriverPlaceModel BirthPlace { get; set; }

    [JsonProperty("DRIVERADDRESS")]
    public DriverPlaceModel Address { get; set; }
    [JsonProperty("CATEGORIES")]
    public List<DriverCategoryModel> Categorys { get; set; }
}
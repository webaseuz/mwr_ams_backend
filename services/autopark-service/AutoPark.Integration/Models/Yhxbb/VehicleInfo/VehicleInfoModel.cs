using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleInfoModel
{
    [JsonProperty("PVEHICLEID")]
    public int VehicleId { get; set; }

    [JsonProperty("PTEXPASSPORTSERY")]
    public string TechPassportSeries { get; set; }

    [JsonProperty("PTEXPASSPORTNUMBER")]
    public string TechPassportNumber { get; set; }

    [JsonProperty("PPLATENUMBER")]
    public string PlateNumber { get; set; }

    [JsonProperty("PMODEL")]
    public string Model { get; set; }

    [JsonProperty("PVEHICLECOLOR")]
    public string VehicleColor { get; set; }

    [JsonProperty("PREGISTRATIONDATE")]
    public DateTime RegistrationDate { get; set; }

    [JsonProperty("PDIVISION")]
    public string Division { get; set; }

    [JsonProperty("PYEAR")]
    public int Year { get; set; }

    [JsonProperty("PVEHICLETYPE")]
    public int VehicleTypeId { get; set; }

    [JsonProperty("PKUZOV")]
    public string KuzovNumber { get; set; }

    [JsonProperty("PSHASSI")]
    public string ShassiNumber { get; set; }

    [JsonProperty("PFULLWEIGHT")]
    public int FullWeight { get; set; }

    [JsonProperty("PEMPTYWEIGHT")]
    public int EmptyWeight { get; set; }

    [JsonProperty("PMOTOR")]
    public string MotorNumber { get; set; }

    [JsonProperty("PFUELTYPE")]
    public int FuelTypeId { get; set; }

    [JsonProperty("PSEATS")]
    public int Seats { get; set; }

    [JsonProperty("PSTANDS")]
    public int Stands { get; set; }

    [JsonProperty("PCOMMENTS")]
    public string Comments { get; set; }

    [JsonProperty("PPOWER")]
    public int Power { get; set; }

    [JsonProperty("PDATESCHETSPRAVKA")]
    public string DateSchetSpravka { get; set; }

    [JsonProperty("PTUNINGPERMIT")]
    public string TuningPermit { get; set; }

    [JsonProperty("PTUNINGGIVENDATE")]
    public string TuningGivenDate { get; set; }

    [JsonProperty("PTUNINGISSUEDATE")]
    public string TuningIssueDate { get; set; }

    [JsonProperty("PREVPNFL")]
    public string PreviousPinfl { get; set; }

    [JsonProperty("PREVOWNER")]
    public string PreviousOwner { get; set; }

    [JsonProperty("PREVOWNERTYPE")]
    public int? PreviousOwnerType { get; set; }

    [JsonProperty("PREVPLATENUMBER")]
    public string PreviousPlateNumber { get; set; }

    [JsonProperty("PREVTEXPASPORTSERY")]
    public string PreviousTechPassportSeries { get; set; }

    [JsonProperty("PREVTEXPASPORTNUMBER")]
    public string PreviousTechPassportNumber { get; set; }

    [JsonProperty("STATE")]
    public int State { get; set; }

    [JsonProperty("NEXTINSPECTIONDATE")]
    public string NextInspectionDate { get; set; }
    [JsonProperty("ADDRESS")]
    public DriverPlaceModel Address { get; set; }
}
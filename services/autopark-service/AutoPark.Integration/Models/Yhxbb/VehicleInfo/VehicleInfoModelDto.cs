namespace AutoPark.Integration.Models;

public class VehicleInfoModelDto
{
    public int VehicleId { get; set; }
    public string TechPassportSeries { get; set; }
    public string TechPassportNumber { get; set; }
    public string PlateNumber { get; set; }
    public string Model { get; set; }
    public string VehicleColor { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Division { get; set; }
    public int Year { get; set; }
    public int VehicleTypeId { get; set; }
    public string KuzovNumber { get; set; }
    public string ShassiNumber { get; set; }
    public int FullWeight { get; set; }
    public int EmptyWeight { get; set; }
    public string MotorNumber { get; set; }
    public int FuelTypeId { get; set; }
    public int Seats { get; set; }
    public int Stands { get; set; }
    public string Comments { get; set; }
    public int Power { get; set; }
    public string DateSchetSpravka { get; set; }
    public string TuningPermit { get; set; }
    public string TuningGivenDate { get; set; }
    public string TuningIssueDate { get; set; }
    public string PreviousPinfl { get; set; }
    public string PreviousOwner { get; set; }
    public int? PreviousOwnerType { get; set; }
    public string PreviousPlateNumber { get; set; }
    public string PreviousTechPassportSeries { get; set; }
    public string PreviousTechPassportNumber { get; set; }
    public int State { get; set; }
    public string NextInspectionDate { get; set; }
    public DriverPlaceModelDto Address { get; set; }
}
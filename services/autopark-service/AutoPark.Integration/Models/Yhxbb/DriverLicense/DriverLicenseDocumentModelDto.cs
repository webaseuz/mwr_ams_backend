namespace AutoPark.Integration.Models;

public class DriverLicenseDocumentModelDto
{
    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? IssuedBy { get; set; }

    public string SerialNumber { get; set; }
}
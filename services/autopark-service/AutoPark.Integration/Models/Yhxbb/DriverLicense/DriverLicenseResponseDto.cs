namespace AutoPark.Integration.Models;

public class DriverLicenseResponseDto
{
    public int Result { get; set; }

    public string Comment { get; set; }

    public string Pinfl { get; set; }

    public string DriverDocument { get; set; }

    public string DriverFullName { get; set; }

    public DateTime DriverBirthOn { get; set; }

    public DateTime DocumentStartDate { get; set; }

    public DateTime DocumentEndDate { get; set; }

    public DriverLicenseDocumentModelDto DocumentInfo { get; set; }

    public DriverPlaceModelDto BirthPlace { get; set; }

    public DriverPlaceModelDto Address { get; set; }
    public List<DriverCategoryModelDto> Categorys { get; set; }
}
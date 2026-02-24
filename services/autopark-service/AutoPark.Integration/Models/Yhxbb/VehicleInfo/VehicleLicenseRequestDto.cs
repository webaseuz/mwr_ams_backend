using System.ComponentModel.DataAnnotations;

namespace AutoPark.Integration.Models;

public class VehicleLicenseRequestDto
{
    [Required]
    public string TexPassportSery { get; set; }
    [Required]
    public string TexPassportNumber { get; set; }
    [Required]
    public string PlateNumber { get; set; }
}

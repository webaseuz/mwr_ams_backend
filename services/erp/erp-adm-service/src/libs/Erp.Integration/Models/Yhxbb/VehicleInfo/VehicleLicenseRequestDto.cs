using System.ComponentModel.DataAnnotations;

namespace Erp.Integration.Models;

public class VehicleLicenseRequestDto
{
    [Required]
    public string TexPassportSery { get; set; }
    [Required]
    public string TexPassportNumber { get; set; }
    [Required]
    public string PlateNumber { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace AutoPark.Integration.Models;

public class DriverLicenseRequestDto
{
    [Required]
    public string PassportSeries { get; set; }
    [Required]
    public string PassportNumber { get; set; }
    [Required]
    public string Pinfl { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class InsuranceTypeDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string OrderCode { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Required]
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<InsuranceTypeTranslateDto> Translates { get; set; } = new();
}

using System.ComponentModel.DataAnnotations;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class BatteryTypeDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string OrderCode { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(500)]
    public string FullName { get; set; } = null!;
    [Required]
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public List<BatteryTypeTranslateDto> Translates { get; set; } = new();
}

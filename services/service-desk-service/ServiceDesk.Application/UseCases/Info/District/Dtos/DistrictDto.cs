using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Application.UseCases.Districts;

public class DistrictDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string OrderCode { get; set; }
    [StringLength(50)]
    public string Code { get; set; }
    [StringLength(50)]
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    public int RegionId { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<DistrictTranslateDto> Translates { get; set; } = new();

}

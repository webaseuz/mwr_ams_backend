using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Application.UseCases.Countries;

public class CountryDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string OrderCode { get; set; }
    [StringLength(50)]
    public string Code { get; set; } = null!;
    [StringLength(50)]
    public string TextCode { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Required]
    public int StateId { get; set; }
    public string StateName { get; set; }

    public List<CountryTranslateDto> Translates { get; set; } = new();

}

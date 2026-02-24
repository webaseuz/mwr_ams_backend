using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipDto
{
    public int Id { get; set; }
    [StringLength(50)]
    public string WbCode { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [Required]
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public List<CitizenshipTranslateDto> Translates { get; set; } = new();
}

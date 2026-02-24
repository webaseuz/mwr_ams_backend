using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CurrencyDto
{
    public int Id { get; set; }
    [Required]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;
    [Required]
    [StringLength(250)]
    public string FullName { get; set; } = null!;
    [StringLength(50)]
    public string Code { get; set; } = null!;
    [StringLength(50)]
    public string TextCode { get; set; } = null!;
    public Guid? PictureId { get; set; }
    public bool IsMain { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }

    public List<CurrencyTranslateDto> Translates { get; set; } = new();
}

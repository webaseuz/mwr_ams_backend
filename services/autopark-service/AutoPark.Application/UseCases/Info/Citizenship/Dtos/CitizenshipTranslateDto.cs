using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPark.Application.UseCases.Citizenships;

public class CitizenshipTranslateDto
{
    [Required]
    [DefaultValue(0)]
    public int Id { get; set; }
    [Required]
    [DefaultValue(0)]
    public int OwnerId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    [Required]
    [StringLength(60)]
    public string ColumnName { get; set; }
    [Required]
    [StringLength(1000)]
    public string TranslateText { get; set; }
}

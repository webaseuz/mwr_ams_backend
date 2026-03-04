namespace Erp.Service.Adm.Models;

public class PositionTranslateDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int LanguageId { get; set; }
    public string? LanguageName { get; set; }
    public string ColumnName { get; set; } = null!;
    public string TranslateText { get; set; } = null!;
}

namespace Erp.Core;

public class TranslateDto
{
    public string ColumnName { get; set; }
    public int LanguageId { get; set; }
    public string Language { get; set; }
    public string TranslateText { get; set; } = string.Empty;
}

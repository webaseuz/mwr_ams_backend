namespace AutoPark.Application.UseCases.OilModels;

public class OilModelTranslateDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    public string ColumnName { get; set; }
    public string TranslateText { get; set; }
}

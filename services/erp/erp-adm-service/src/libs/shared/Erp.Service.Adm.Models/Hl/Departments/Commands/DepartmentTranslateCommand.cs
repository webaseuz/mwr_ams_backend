namespace Erp.Service.Adm.Models;

public class DepartmentTranslateCommand
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string ColumnName { get; set; } = null!;
    public string TranslateText { get; set; } = null!;
}

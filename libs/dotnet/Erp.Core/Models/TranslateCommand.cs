using System.Text.Json.Serialization;

namespace Erp.Core;

public interface ITranslateCommand
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TranslateColumn ColumnName { get; set; }
    public int LanguageId { get; set; }
    public string TranslateText { get; set; }
}

public class TranslateCommand : ITranslateCommand
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TranslateColumn ColumnName { get; set; }
    public int LanguageId { get; set; }
    public string TranslateText { get; set; } = string.Empty;

    public string GetUniqueForeignKey() => $"{ColumnName}_{LanguageId}";
}

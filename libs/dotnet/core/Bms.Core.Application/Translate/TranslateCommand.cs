using Bms.WEBASE.Models;

namespace Bms.Core.Application;

public class TranslateCommand<TTranslateCommand, TEntity, TTranslateColumn> :
    IHaveUniqueForeignKey
        where TEntity : class
        where TTranslateColumn : struct
{
    public virtual TTranslateColumn ColumnName { get; set; }
    public int LanguageId { get; set; }
    public string TranslateText { get; set; }
    public object GetUniqueForeignKey() => $"{ColumnName}_{LanguageId}";
}

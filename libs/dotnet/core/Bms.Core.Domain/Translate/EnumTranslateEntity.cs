using Bms.WEBASE.Models;
using Bms.WEBASE.Translate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Bms.Core.Application;
public abstract class EnumTranslateEntity<TTranslate, TTranslateColumn> :
    EnumTranslateEntity<TTranslate, TTranslateColumn, int>
        where TTranslate : EnumTranslateEntity<TTranslate, TTranslateColumn>
        where TTranslateColumn : struct
{
}

public abstract class EnumTranslateEntity<TTranslate, TTranslateColumn, TOwnerId> :
    IHaveUniqueForeignKey,
    ITranslate
        where TTranslate : EnumTranslateEntity<TTranslate, TTranslateColumn, TOwnerId>
        where TTranslateColumn : struct
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("owner_id")]
    public TOwnerId OwnerId { get; set; }

    [Required]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Required]
    [Column("column_name")]
    [StringLength(60)]
    public string ColumnName { get; set; } = string.Empty;

    [Required]
    [Column("translate_text")]
    public string TranslateText { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Required]
    [Column("created_at")]

    public DateTime CreatedAt { get; set; }

    public static Expression<Func<TTranslate, bool>> GetExpr(TTranslateColumn column, int languageId)
    {
        string columnName = column.ToString()!;
        return a => a.LanguageId == languageId && a.ColumnName == columnName;
    }

    public object GetUniqueForeignKey() => $"{ColumnName}_{LanguageId}";

}


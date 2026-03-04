using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using WEBASE;

namespace Erp.Core.Service.Domain;

public class BaseTranslateEntity<TTranslate, TTranslateColumn, TOwnerId, TOwnerEntity> : BaseEntity<TOwnerId>,
    ITranslateEntity<TOwnerId, TOwnerEntity>, IWbAuditProp, IHaveUniqueForeignKey
    where TTranslate : BaseTranslateEntity<TTranslate, TTranslateColumn, TOwnerId, TOwnerEntity>
    where TOwnerEntity : IWbEntity<TOwnerId>
    where TOwnerId : struct
{
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("translate_text")]
    public string TranslateText { get; set; }

    [Column("column_name")]
    public string ColumnName { get; set; }

    [Column("owner_id")]
    public TOwnerId OwnerId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("last_modified_at")]
    public DateTime? LastModifiedAt { get; set; }

    // Navigation properties
    public Language Language { get; set; } = default!;
    public TOwnerEntity Owner { get; set; } = default!;

    public object GetUniqueForeignKey() => $"{ColumnName}_{LanguageId}";

    public static Expression<Func<TTranslate, bool>> GetExpr(TTranslateColumn column, int languageId)
    {
        string columnName = column.ToString().ToLower();
        return a => a.LanguageId == languageId && a.ColumnName.ToLower() == columnName;
    }
}

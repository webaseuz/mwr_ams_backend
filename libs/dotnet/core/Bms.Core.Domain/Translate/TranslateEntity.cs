using System.ComponentModel.DataAnnotations.Schema;

namespace Bms.Core.Application;

public abstract class TranslateEntity<TTranslateEntity, TTranslateColumn> :
    TranslateEntity<TTranslateEntity, TTranslateColumn, int>
        where TTranslateEntity : TranslateEntity<TTranslateEntity, TTranslateColumn>
        where TTranslateColumn : struct
{
}

public abstract class TranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId> :
    EnumTranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId>
        where TTranslateEntity : TranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId>
        where TTranslateColumn : struct
{
    [Column("modified_at")]
    public DateTime? ModifiedAt { get; set; }
}

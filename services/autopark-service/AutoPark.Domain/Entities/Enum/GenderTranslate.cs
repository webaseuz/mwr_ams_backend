using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_gender_translate")]
public class GenderTranslate :
    EnumTranslateEntity<GenderTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual Gender Owner { get; set; } = null!;
}

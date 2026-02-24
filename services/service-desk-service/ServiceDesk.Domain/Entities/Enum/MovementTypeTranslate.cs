using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_movement_type_translate")]
public class MovementTypeTranslate :
    EnumTranslateEntity<MovementTypeTranslate,TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual MovementType Owner { get; set; } = null!;
}

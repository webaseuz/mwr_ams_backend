using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_plastic_card_type_translate")]
public class PlasticCardTypeTranslate :
    EnumTranslateEntity<PlasticCardTypeTranslate, TranslateColumn>
{

    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual PlasticCardType Owner { get; set; } = null!;
}

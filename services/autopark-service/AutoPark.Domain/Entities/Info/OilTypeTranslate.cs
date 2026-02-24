using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_oil_type_translate")]
public class OilTypeTranslate :
    TranslateEntity<OilTypeTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual OilType Owner { get; set; } = null!;
}

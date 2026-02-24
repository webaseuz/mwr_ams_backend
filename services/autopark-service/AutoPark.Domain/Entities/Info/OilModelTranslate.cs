using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_oil_model_translate")]
public class OilModelTranslate :
    TranslateEntity<OilModelTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual OilModel Owner { get; set; } = null!;
}

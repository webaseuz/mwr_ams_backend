using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("info_transport_brand_translate")]
public class TransportBrandTranslate :
    TranslateEntity<TransportBrandTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransportBrand Owner { get; set; } = null!;
}

using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_transmission_box_type_translate")]
public class TransmissionBoxTypeTranslate
    : TranslateEntity<TransmissionBoxTypeTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual TransmissionBoxType Owner { get; set; } = null!;
}

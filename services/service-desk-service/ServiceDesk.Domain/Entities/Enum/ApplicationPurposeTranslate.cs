using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_application_purpose_translate")]
public class ApplicationPurposeTranslate :
    EnumTranslateEntity<ApplicationPurposeTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual ApplicationPurpose Owner { get; set; } = null!;
}

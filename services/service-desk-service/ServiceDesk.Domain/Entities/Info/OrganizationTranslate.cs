using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_organization_translate")]
public class OrganizationTranslate :
    TranslateEntity<OrganizationTranslate , TranslateColumn>
{
    [ForeignKey("LanguageId")]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey("OwnerId")]
    public virtual Organization Owner { get; set; } = null!;
}

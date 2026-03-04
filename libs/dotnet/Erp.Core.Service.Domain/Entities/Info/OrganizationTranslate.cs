using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_organization_translate")]
public class OrganizationTranslate :
    BaseTranslateEntity<OrganizationTranslate, TranslateColumn, int, Organization>
{
 
}

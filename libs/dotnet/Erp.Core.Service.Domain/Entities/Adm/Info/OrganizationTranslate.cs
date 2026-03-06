using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_organization_translate", Schema = "adm")]
public class OrganizationTranslate :
    BaseTranslateEntity<OrganizationTranslate, TranslateColumn, int, Organization>
{
 
}

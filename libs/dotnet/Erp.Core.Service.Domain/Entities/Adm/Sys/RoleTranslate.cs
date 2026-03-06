using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_role_translate", Schema = "adm")]
public class RoleTranslate
    : BaseTranslateEntity<RoleTranslate, TranslateColumn, int, Role>
{

}

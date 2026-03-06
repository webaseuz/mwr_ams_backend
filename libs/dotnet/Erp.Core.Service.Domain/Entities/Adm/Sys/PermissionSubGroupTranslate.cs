using Erp.Core.Service.Domain.Entities.Sys;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_permission_sub_group_translate", Schema = "adm")]
public class PermissionSubGroupTranslate :
    BaseTranslateEntity<PermissionSubGroupTranslate, TranslateColumn, int, PermissionSubGroup>
{

}

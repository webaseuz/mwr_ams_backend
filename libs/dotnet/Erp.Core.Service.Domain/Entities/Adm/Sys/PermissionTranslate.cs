using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain.Entities.Sys
{
    [Table("sys_permission_translate", Schema = "adm")]
    public class PermissionTranslate :
        BaseTranslateEntity<PermissionTranslate, TranslateColumn, int, Permission>
    {

    }
}

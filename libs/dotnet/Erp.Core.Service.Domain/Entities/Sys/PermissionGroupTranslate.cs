using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain.Entities.Sys
{
    [Table("sys_permission_group_translate")]
    public class PermissionGroupTranslate :
         BaseTranslateEntity<PermissionGroupTranslate, TranslateColumn, int, PermissionGroup>
    {

    }
}

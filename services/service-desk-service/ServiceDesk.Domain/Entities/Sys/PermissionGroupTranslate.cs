using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain.Entities.Sys
{
    [Table("sys_permission_group_translate")]
    public class PermissionGroupTranslate :
         TranslateEntity<PermissionGroupTranslate, TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public virtual PermissionGroup Owner { get; set; } = null!;
    }
}

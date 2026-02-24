using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain.Entities.Sys
{
    [Table("sys_permission_translate")]
    public class PermissionTranslate :
        TranslateEntity<PermissionTranslate, TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public virtual Permission Owner { get; set; } = null!;
    }
}

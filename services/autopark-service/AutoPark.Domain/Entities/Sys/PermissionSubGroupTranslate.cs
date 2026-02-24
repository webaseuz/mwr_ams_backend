using AutoPark.Domain.Entities.Sys;
using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_permission_sub_group_translate")]
public class PermissionSubGroupTranslate :
    TranslateEntity<PermissionSubGroupTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual PermissionSubGroup Owner { get; set; } = null!;
}

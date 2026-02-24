using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("info_device_spare_type_translate")]
public class DeviceSpareTypeTranslate :
    TranslateEntity<DeviceSpareTypeTranslate, TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual DeviceSpareType Owner { get; set; } = null!;
}

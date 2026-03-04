using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_battery_type_translate")]
public class BatteryTypeTranslate :
    BaseTranslateEntity<BatteryTypeTranslate, TranslateColumn, int, BatteryType>
{

}

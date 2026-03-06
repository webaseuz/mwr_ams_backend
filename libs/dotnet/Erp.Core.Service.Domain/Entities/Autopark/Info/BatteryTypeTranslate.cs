using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_battery_type_translate", Schema = "autopark")]
public class BatteryTypeTranslate :
    BaseTranslateEntity<BatteryTypeTranslate, TranslateColumn, int, BatteryType>
{

}

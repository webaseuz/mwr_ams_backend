using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_liquid_type_translate", Schema = "autopark")]
public class LiquidTypeTranslate
    : BaseTranslateEntity<LiquidTypeTranslate, TranslateColumn, int, LiquidType>
{

}

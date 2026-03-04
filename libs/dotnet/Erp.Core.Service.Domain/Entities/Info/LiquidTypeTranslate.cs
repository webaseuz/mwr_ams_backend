using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_liquid_type_translate")]
public class LiquidTypeTranslate
    : BaseTranslateEntity<LiquidTypeTranslate, TranslateColumn, int, LiquidType>
{

}

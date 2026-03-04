using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_fuel_type_translate")]
public class FuelTypeTranslate :
    BaseTranslateEntity<FuelTypeTranslate, TranslateColumn, int, FuelType>
{

}

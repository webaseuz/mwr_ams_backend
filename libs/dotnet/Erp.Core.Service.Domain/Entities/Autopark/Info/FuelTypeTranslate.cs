using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_fuel_type_translate", Schema = "autopark")]
public class FuelTypeTranslate :
    BaseTranslateEntity<FuelTypeTranslate, TranslateColumn, int, FuelType>
{

}

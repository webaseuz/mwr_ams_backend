using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_tire_model_translate")]
public class TireModelTranslate :
    BaseTranslateEntity<TireModelTranslate, TranslateColumn, int, TireModel>
{

}

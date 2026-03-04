using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_oil_model_translate")]
public class OilModelTranslate :
    BaseTranslateEntity<OilModelTranslate, TranslateColumn, int, OilModel>
{

}

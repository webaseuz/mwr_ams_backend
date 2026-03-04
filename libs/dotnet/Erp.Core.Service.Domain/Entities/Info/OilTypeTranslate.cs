using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_oil_type_translate")]
public class OilTypeTranslate :
    BaseTranslateEntity<OilTypeTranslate, TranslateColumn, int, OilType>
{

}

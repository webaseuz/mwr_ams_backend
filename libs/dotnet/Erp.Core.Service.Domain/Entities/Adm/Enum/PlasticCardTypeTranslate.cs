using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_plastic_card_type_translate", Schema = "adm")]
public class PlasticCardTypeTranslate :
   BaseTranslateEntity<PlasticCardTypeTranslate, TranslateColumn, int, PlasticCardType>
{

}

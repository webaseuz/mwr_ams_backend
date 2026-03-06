using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_currency_translate", Schema = "adm")]
public class CurrencyTranslate :
    BaseTranslateEntity<CurrencyTranslate, TranslateColumn, int, Currency>
{

}

using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_currency_translate")]
public class CurrencyTranslate :
    BaseTranslateEntity<CurrencyTranslate, TranslateColumn, int, Currency>
{

}

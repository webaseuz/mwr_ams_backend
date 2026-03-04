using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_country_translate")]
public class CountryTranslate :
    BaseTranslateEntity<CountryTranslate, TranslateColumn, int, Country>
{

}

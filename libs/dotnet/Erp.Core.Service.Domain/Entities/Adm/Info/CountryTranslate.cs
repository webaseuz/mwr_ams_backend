using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_country_translate", Schema = "adm")]
public class CountryTranslate :
    BaseTranslateEntity<CountryTranslate, TranslateColumn, int, Country>
{

}

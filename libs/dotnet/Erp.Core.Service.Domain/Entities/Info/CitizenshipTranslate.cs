using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_citizenship_translate")]
public class CitizenshipTranslate :
    BaseTranslateEntity<CitizenshipTranslate, TranslateColumn, int, Citizenship>
{

}

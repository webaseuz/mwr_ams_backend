using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_citizenship_translate", Schema = "adm")]
public class CitizenshipTranslate :
    BaseTranslateEntity<CitizenshipTranslate, TranslateColumn, int, Citizenship>
{

}

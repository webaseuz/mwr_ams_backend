using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_nationality_translate", Schema = "adm")]
public class NationalityTranslate :
    BaseTranslateEntity<NationalityTranslate, TranslateColumn, int, Nationality>
{

}

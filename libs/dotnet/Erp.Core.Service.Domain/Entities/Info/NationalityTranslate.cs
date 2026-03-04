using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_nationality_translate")]
public class NationalityTranslate :
    BaseTranslateEntity<NationalityTranslate, TranslateColumn, int, Nationality>
{

}

using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_gender_translate", Schema = "adm")]
public class GenderTranslate :
    BaseTranslateEntity<GenderTranslate, TranslateColumn, int, Gender>
{

}

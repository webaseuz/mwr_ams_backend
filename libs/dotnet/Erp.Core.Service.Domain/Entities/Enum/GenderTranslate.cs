using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_gender_translate")]
public class GenderTranslate :
    BaseTranslateEntity<GenderTranslate, TranslateColumn, int, Gender>
{

}

using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_status_translate", Schema = "adm")]
public class StatusTranslate :
    BaseTranslateEntity<StatusTranslate, TranslateColumn, int, Status>
{

}

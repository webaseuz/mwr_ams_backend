using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_status_translate")]
public class StatusTranslate :
    BaseTranslateEntity<StatusTranslate, TranslateColumn, int, Status>
{

}

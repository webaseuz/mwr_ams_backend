using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_notification_template_translate", Schema = "adm")]
public class NotificationTemplateTranslate :
    BaseTranslateEntity<NotificationTemplateTranslate, TranslateColumn, int, NotificationTemplate>
{

}

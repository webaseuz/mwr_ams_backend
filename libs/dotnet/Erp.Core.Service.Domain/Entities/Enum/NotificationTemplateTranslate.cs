using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_notification_template_translate")]
public class NotificationTemplateTranslate :
    BaseTranslateEntity<NotificationTemplateTranslate, TranslateColumn, int, NotificationTemplate>
{

}

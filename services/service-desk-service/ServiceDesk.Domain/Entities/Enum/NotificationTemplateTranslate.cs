using Bms.Core.Application;
using Bms.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("enum_notification_template_translate")]
public class NotificationTemplateTranslate :
	EnumTranslateEntity<NotificationTemplateTranslate, TranslateColumn>
{
	[ForeignKey(nameof(LanguageId))]
	public virtual Language Language { get; set; } = null!;

	[ForeignKey(nameof(OwnerId))]
	public virtual NotificationTemplate Owner { get; set; } = null!;
}

using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingUserCommand :
	IHaveIdProp<long>
{
	public long Id { get; set; }
	public int UserId { get; set; }
}

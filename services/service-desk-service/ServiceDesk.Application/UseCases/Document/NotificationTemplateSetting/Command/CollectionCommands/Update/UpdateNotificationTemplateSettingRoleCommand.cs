using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRoleCommand :
	IHaveIdProp<long>
{
	public long Id { get; set; }
	public int RoleId { get; set; }
}

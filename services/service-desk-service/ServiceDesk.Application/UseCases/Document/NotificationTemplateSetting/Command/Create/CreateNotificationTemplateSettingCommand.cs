using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingCommand :
	IRequest<IHaveId<long>>
{
	public string DocNumber { get; set; } = null!;
	public DateTime DocDate { get; set; }
	public int? BranchId { get; set; }
	public int NotificationTemplateId { get; set; }
	public List<CreateNotificationTemplateSettingUserCommand> Users { get; set; } = new List<CreateNotificationTemplateSettingUserCommand>();
	public List<CreateNotificationTemplateSettingRoleCommand> Roles { get; set; } = new List<CreateNotificationTemplateSettingRoleCommand>();
	public List<CreateNotificationTemplateSettingRestrictedUserCommand> RestrictedUsers { get; set; } = new List<CreateNotificationTemplateSettingRestrictedUserCommand>();
}

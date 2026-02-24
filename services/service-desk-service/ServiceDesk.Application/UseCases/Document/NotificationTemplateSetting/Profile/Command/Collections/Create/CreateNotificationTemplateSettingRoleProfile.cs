using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingRoleProfile : Profile
{
	public CreateNotificationTemplateSettingRoleProfile()
	{
		CreateMap<CreateNotificationTemplateSettingRoleCommand, NotificationTemplateSettingRole>();
	}
}
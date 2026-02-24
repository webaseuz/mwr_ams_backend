using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRoleProfile : Profile
{
	public UpdateNotificationTemplateSettingRoleProfile()
	{
		CreateMap<UpdateNotificationTemplateSettingRoleCommand, NotificationTemplateSettingRole>();
	}
}
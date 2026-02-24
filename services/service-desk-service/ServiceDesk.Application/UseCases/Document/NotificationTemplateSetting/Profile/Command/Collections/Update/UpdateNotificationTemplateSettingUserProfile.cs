using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingUserProfile : Profile
{
	public UpdateNotificationTemplateSettingUserProfile()
	{
		CreateMap<UpdateNotificationTemplateSettingUserCommand, NotificationTemplateSettingUser>();
	}
}
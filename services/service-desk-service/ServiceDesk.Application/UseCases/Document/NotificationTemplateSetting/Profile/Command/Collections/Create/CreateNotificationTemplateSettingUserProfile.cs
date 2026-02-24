using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingUserProfile : Profile
{
	public CreateNotificationTemplateSettingUserProfile()
	{
		CreateMap<CreateNotificationTemplateSettingUserCommand, NotificationTemplateSettingUser>();
	}
}
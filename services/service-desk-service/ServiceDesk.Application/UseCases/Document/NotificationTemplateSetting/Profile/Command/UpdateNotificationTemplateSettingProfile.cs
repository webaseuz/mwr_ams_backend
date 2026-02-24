using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingProfile : Profile
{
    public UpdateNotificationTemplateSettingProfile()
    {
		CreateMap<UpdateNotificationTemplateSettingCommand, NotificationTemplateSetting>()
			.ForMember(src => src.Users, conf => conf.Ignore())
			.ForMember(src => src.Roles, conf => conf.Ignore())
			.ForMember(src => src.RestrictedUsers, conf => conf.Ignore())
			;
	}
}

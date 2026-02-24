using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingUserDtoProfile : Profile
{
	public NotificationTemplateSettingUserDtoProfile()
	{
		CreateMap<NotificationTemplateSettingUser, NotificationTemplateSettingUserDto>()
			.ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
			;
	}
}

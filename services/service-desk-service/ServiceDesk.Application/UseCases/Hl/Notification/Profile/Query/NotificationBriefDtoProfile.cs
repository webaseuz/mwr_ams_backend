using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Notifications;

public class NotificationBriefDtoProfile : Profile
{
	public NotificationBriefDtoProfile()
	{
		CreateMap<Notification, NotificationBriefDto>()
			.ForMember(src => src.NotificationTempleteName, conf => conf.MapFrom(ent => ent.NotificationTemplate.Key))
			.ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
			.ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName))
			;
	}
}

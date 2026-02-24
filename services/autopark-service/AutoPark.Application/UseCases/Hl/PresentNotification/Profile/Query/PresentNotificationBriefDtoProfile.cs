using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.PresentNotifications;

public class PresentNotificationBriefDtoProfile : Profile
{
    public PresentNotificationBriefDtoProfile()
    {
        CreateMap<PresentNotification, PresentNotificationBriefDto>()
            .ForMember(src => src.NotificationTempleteName, conf => conf.MapFrom(ent => ent.NotificationTemplate.Key))
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
            ;
    }
}

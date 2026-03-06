using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class PresentNotificationBriefDtoProfile : Profile
{
    public PresentNotificationBriefDtoProfile()
    {
        CreateMap<PresentNotification, PresentNotificationBriefDto>()
            .ForMember(src => src.NotificationTempleteName, conf => conf.MapFrom(ent => ent.NotificationTemplate.Key))
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName));
    }
}

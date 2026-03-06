using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationDtoProfile : Profile
{
    public NotificationDtoProfile()
    {
        CreateMap<Notification, NotificationDto>()
            .ForMember(src => src.NotificationTempleteName, conf => conf.MapFrom(ent => ent.NotificationTemplate.Key))
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));
    }
}

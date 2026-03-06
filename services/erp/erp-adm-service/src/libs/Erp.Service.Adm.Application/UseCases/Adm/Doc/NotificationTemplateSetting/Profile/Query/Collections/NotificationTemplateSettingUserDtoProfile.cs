using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationTemplateSettingUserDtoProfile : Profile
{
    public NotificationTemplateSettingUserDtoProfile()
    {
        CreateMap<NotificationTemplateSettingUser, NotificationTemplateSettingUserDto>()
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName));
    }
}

using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationTemplateSettingRestrictedUserDtoProfile : Profile
{
    public NotificationTemplateSettingRestrictedUserDtoProfile()
    {
        CreateMap<NotificationTemplateSettingRestrictedUser, NotificationTemplateSettingRestrictedUserDto>()
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName));
    }
}

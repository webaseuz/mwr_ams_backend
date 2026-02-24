using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingRestrictedUserDtoProfile : Profile
{
    public NotificationTemplateSettingRestrictedUserDtoProfile()
    {
        CreateMap<NotificationTemplateSettingRestrictedUser, NotificationTemplateSettingRestrictedUserDto>()
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
            ;
    }
}

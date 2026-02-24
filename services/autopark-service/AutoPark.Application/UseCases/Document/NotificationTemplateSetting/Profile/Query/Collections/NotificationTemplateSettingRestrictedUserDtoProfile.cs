using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingRestrictedUserDtoProfile : Profile
{
    public NotificationTemplateSettingRestrictedUserDtoProfile()
    {
        CreateMap<NotificationTemplateSettingRestrictedUser, NotificationTemplateSettingRestrictedUserDto>()
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
            ;
    }
}

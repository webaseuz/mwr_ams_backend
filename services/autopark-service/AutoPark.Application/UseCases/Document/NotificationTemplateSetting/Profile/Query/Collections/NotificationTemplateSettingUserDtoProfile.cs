using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingUserDtoProfile : Profile
{
    public NotificationTemplateSettingUserDtoProfile()
    {
        CreateMap<NotificationTemplateSettingUser, NotificationTemplateSettingUserDto>()
            .ForMember(src => src.UserName, conf => conf.MapFrom(ent => ent.User.UserName))
            ;
    }
}

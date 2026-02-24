using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingProfile : Profile
{
    public CreateNotificationTemplateSettingProfile()
    {
        CreateMap<CreateNotificationTemplateSettingCommand, NotificationTemplateSetting>()
            .ForMember(src => src.Users, conf => conf.Ignore())
            .ForMember(src => src.Roles, conf => conf.Ignore())
            .ForMember(src => src.RestrictedUsers, conf => conf.Ignore())
            ;
    }
}

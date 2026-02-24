using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingRestrictedUserProfile : Profile
{
    public CreateNotificationTemplateSettingRestrictedUserProfile()
    {
        CreateMap<CreateNotificationTemplateSettingRestrictedUserCommand, NotificationTemplateSettingRestrictedUser>();
    }
}

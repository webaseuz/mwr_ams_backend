using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingRestrictedUserProfile : Profile
{
    public CreateNotificationTemplateSettingRestrictedUserProfile()
    {
        CreateMap<CreateNotificationTemplateSettingRestrictedUserCommand, NotificationTemplateSettingRestrictedUser>();
    }
}

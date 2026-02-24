using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRestrictedUserProfile : Profile
{
    public UpdateNotificationTemplateSettingRestrictedUserProfile()
    {
        CreateMap<UpdateNotificationTemplateSettingRestrictedUserCommand, NotificationTemplateSettingRestrictedUser>();
    }
}

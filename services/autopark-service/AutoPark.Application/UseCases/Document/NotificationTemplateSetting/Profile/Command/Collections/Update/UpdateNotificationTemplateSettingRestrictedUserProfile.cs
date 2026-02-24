using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRestrictedUserProfile : Profile
{
    public UpdateNotificationTemplateSettingRestrictedUserProfile()
    {
        CreateMap<UpdateNotificationTemplateSettingRestrictedUserCommand, NotificationTemplateSettingRestrictedUser>();
    }
}

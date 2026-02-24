using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingUserProfile : Profile
{
    public UpdateNotificationTemplateSettingUserProfile()
    {
        CreateMap<UpdateNotificationTemplateSettingUserCommand, NotificationTemplateSettingUser>();
    }
}
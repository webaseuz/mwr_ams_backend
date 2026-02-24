using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingUserProfile : Profile
{
    public CreateNotificationTemplateSettingUserProfile()
    {
        CreateMap<CreateNotificationTemplateSettingUserCommand, NotificationTemplateSettingUser>();
    }
}
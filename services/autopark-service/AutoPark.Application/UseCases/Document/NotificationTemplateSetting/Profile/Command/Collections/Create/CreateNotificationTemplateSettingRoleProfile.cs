using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingRoleProfile : Profile
{
    public CreateNotificationTemplateSettingRoleProfile()
    {
        CreateMap<CreateNotificationTemplateSettingRoleCommand, NotificationTemplateSettingRole>();
    }
}
using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRoleProfile : Profile
{
    public UpdateNotificationTemplateSettingRoleProfile()
    {
        CreateMap<UpdateNotificationTemplateSettingRoleCommand, NotificationTemplateSettingRole>();
    }
}
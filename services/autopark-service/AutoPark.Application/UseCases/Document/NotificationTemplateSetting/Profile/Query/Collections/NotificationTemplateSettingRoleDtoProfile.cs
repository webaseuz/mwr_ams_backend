using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingRoleDtoProfile : Profile
{
    public NotificationTemplateSettingRoleDtoProfile()
    {
        CreateMap<NotificationTemplateSettingRole, NotificationTemplateSettingRoleDto>()
            .ForMember(src => src.RoleName, conf => conf.MapFrom(ent => ent.Role.FullName))
            ;
    }
}

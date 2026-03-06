using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationTemplateSettingRoleDtoProfile : Profile
{
    public NotificationTemplateSettingRoleDtoProfile()
    {
        CreateMap<NotificationTemplateSettingRole, NotificationTemplateSettingRoleDto>()
            .ForMember(src => src.RoleName, conf => conf.MapFrom(ent => ent.Role.FullName));
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Roles;

public class UpdateRoleCommandProfile : Profile
{
    public UpdateRoleCommandProfile()
    {
        CreateMap<UpdateRoleCommand, Role>()
            .ForMember(src => src.Translates, conf => conf.Ignore())
            .ForMember(src => src.RolePermissions, conf => conf.Ignore());
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Roles;

public class CreateRoleCommandProfile : Profile
{
    public CreateRoleCommandProfile()
    {
        CreateMap<CreateRoleCommand, Role>()
            .ForMember(src => src.Translates, conf => conf.Ignore())
            .ForMember(src => src.RolePermissions, conf => conf.Ignore());
    }
}
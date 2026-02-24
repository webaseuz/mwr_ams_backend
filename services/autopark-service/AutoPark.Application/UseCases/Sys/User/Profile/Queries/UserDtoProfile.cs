using AutoMapper;
using AutoPark.Application.UseCases.Users;
using AutoPark.Domain;

public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName))
            .ForMember(src => src.OrganizationName, conf => conf.MapFrom(ent => ent.Organization.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.DepartmentName, conf => conf.MapFrom(ent => ent.Department.FullName))
            .ForMember(src => src.PositionName, conf => conf.MapFrom(ent => ent.Position.FullName))
            .ForMember(dest => dest.Roles, conf => conf.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId)))
            .ForMember(dest => dest.LanguageName, conf => conf.MapFrom(src => src.Language.ShortName));
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Users;

public class UserBriefDtoProfile : Profile
{
    public UserBriefDtoProfile()
    {
        //UserBriefDto
        CreateMap<User, UserBriefDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Person.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.RegionId, conf => conf.MapFrom(ent => ent.Branch.RegionId))
            .ForMember(src => src.RegionName, conf => conf.MapFrom(ent => ent.Branch.Region.FullName))
            .ForMember(src => src.DistrictId, conf => conf.MapFrom(ent => ent.Branch.DistrictId))
            .ForMember(src => src.DistrictName, conf => conf.MapFrom(ent => ent.Branch.District.FullName))
            .ForMember(src => src.Roles, conf => conf.MapFrom(src => 
                src.UserRoles.Select(ur => ur.Role.ShortName).ToList()))
            .ForMember(dest => dest.CreatedAt, conf => conf.MapFrom(src =>
                src.CreatedAt.ToString("yyyy-MM-dd")))
            .ForMember(dest => dest.ModifiedAt, conf => conf.MapFrom(src =>
                src.CreatedAt.ToString("yyyy-MM-dd")));
    }
}

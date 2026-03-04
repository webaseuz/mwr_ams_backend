using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class UserBriefDtoProfile : Profile
{
    public UserBriefDtoProfile()
    {
        CreateMap<UserRole, UserRoleBriefDto>()
            .ForMember(dest => dest.RoleName, conf => conf.MapFrom(src => src.Role.ShortName))
            .ForMember(dest => dest.AppId, conf => conf.Ignore())
            .ForMember(dest => dest.AppName, conf => conf.Ignore())
            .ForMember(dest => dest.IsAutomatic, conf => conf.Ignore());

        CreateMap<User, UserBriefDto>()
            .ForMember(dest => dest.PersonId, conf => conf.MapFrom(src => (int)src.PersonId))
            .ForMember(dest => dest.State, conf => conf.MapFrom(src => src.State.FullName))
            .ForMember(dest => dest.UserRoles, conf => conf.MapFrom(src =>
                src.UserRoles.Where(x => !x.IsDeleted).ToList()))
            .ForMember(dest => dest.UserOrganizations, conf => conf.Ignore())
            .ForMember(dest => dest.OrderCode, conf => conf.Ignore())
            .ForMember(dest => dest.LastVisitAppId, conf => conf.Ignore())
            .ForMember(dest => dest.LastVisitApp, conf => conf.Ignore())
            .ForMember(dest => dest.LastVisitAt, conf => conf.Ignore());
    }
}

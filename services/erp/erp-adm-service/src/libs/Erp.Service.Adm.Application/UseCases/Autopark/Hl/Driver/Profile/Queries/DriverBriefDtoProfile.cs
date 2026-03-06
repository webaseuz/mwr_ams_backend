using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverBriefDtoProfile : Profile
{
    public DriverBriefDtoProfile()
    {
        CreateMap<Driver, DriverBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName))
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));
    }
}

using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverDtoProfile : Profile
{
    public DriverDtoProfile()
    {
        CreateMap<Driver, DriverDto>()
            .ForMember(src => src.Inn, conf => conf.MapFrom(ent => ent.Person.Inn))
            .ForMember(src => src.Pinfl, conf => conf.MapFrom(ent => ent.Person.Pinfl))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.Pinfl + " - " + ent.Person.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));
    }
}

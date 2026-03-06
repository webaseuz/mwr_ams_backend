using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class PersonBriefDtoProfile : Profile
{
    public PersonBriefDtoProfile()
    {
        CreateMap<Person, PersonBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.FullName));
    }
}

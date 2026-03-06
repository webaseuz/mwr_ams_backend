using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Core.Sdk.Models;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class PersonDtoProfile : Profile
{
    public PersonDtoProfile()
    {
        CreateMap<Person, PersonFullDto>()
            .ForMember(src => src.DocSeria, conf => conf.MapFrom(ent => ent.DocumentSeria))
            .ForMember(src => src.DocNumber, conf => conf.MapFrom(ent => ent.DocumentNumber))
            .ForMember(src => src.DocExpireDate, conf => conf.MapFrom(ent => ent.DocumentEndOn))
            .ForMember(src => src.DocIssueDate, conf => conf.MapFrom(ent => ent.DocumentStartOn))
            .ForMember(src => src.Gender, conf => conf.MapFrom(ent => ent.Gender.FullName))
            .ForMember(src => src.Citizenship, conf => conf.MapFrom(ent => ent.Citizenship.FullName))
            .ForMember(src => src.BirthCountry, conf => conf.MapFrom(ent => ent.BirthCountry.FullName))
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.FullName));
    }
}

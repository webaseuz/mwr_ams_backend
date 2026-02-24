using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationTranslateDtoProfile : Profile
{
    public OrganizationTranslateDtoProfile()
    {
        CreateMap<OrganizationTranslate, OrganizationTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

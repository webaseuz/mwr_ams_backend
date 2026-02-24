using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Organizations;

public class OrganizationTranslateDtoProfile : Profile
{
    public OrganizationTranslateDtoProfile()
    {
        CreateMap<OrganizationTranslate, OrganizationTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

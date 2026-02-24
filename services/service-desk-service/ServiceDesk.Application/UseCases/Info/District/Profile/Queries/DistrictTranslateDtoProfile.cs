using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Districts;

public class DistrictTranslateDtoProfile : Profile
{
    public DistrictTranslateDtoProfile()
    {
        CreateMap<DistrictTranslate, DistrictTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

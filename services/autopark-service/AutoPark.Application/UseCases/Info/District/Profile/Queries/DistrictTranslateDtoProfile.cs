using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Districts;

public class DistrictTranslateDtoProfile : Profile
{
    public DistrictTranslateDtoProfile()
    {
        CreateMap<DistrictTranslate, DistrictTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

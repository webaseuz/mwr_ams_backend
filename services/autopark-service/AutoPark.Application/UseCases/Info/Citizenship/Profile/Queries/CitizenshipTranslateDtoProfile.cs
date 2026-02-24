using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Citizenships;

public class CitizenshipTranslateDtoProfile : Profile
{
    public CitizenshipTranslateDtoProfile()
    {
        CreateMap<CitizenshipTranslate, CitizenshipTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
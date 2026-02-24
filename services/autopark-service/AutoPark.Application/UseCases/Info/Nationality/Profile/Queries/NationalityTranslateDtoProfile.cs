using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Nationalities;

public class NationalityTranslateDtoProfile : Profile
{
    public NationalityTranslateDtoProfile()
    {
        CreateMap<NationalityTranslate, NationalityTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

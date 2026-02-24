using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class NationalityTranslateDtoProfile : Profile
{
    public NationalityTranslateDtoProfile()
    {
        CreateMap<NationalityTranslate, NationalityTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

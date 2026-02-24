using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class PositionTranslateDtoProfile : Profile
{
    public PositionTranslateDtoProfile()
    {
        CreateMap<PositionTranslate, PositionTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelTypes;

public class FuelTypeTranslateDtoProfile : Profile
{
    public FuelTypeTranslateDtoProfile()
    {
        CreateMap<FuelTypeTranslate, FuelTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class InsuranceTypeTranslateDtoProfile : Profile
{
    public InsuranceTypeTranslateDtoProfile()
    {
        CreateMap<InsuranceTypeTranslate, InsuranceTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

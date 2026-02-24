using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class BankTranslateDtoProfile : Profile
{
    public BankTranslateDtoProfile()
    {
        CreateMap<BankTranslate, BankTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

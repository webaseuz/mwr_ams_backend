using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class CurrencyTranslateDtoProfile : Profile
{
    public CurrencyTranslateDtoProfile()
    {
        CreateMap<CurrencyTranslate, CurrencyTranslateDto>()
            .ForMember(src => src.Language, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

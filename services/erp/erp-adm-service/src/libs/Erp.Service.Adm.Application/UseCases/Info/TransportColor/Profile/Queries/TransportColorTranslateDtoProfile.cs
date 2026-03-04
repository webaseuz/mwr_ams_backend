using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportColorTranslateDtoProfile : Profile
{
    public TransportColorTranslateDtoProfile()
    {
        CreateMap<TransportColorTranslate, TransportColorTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

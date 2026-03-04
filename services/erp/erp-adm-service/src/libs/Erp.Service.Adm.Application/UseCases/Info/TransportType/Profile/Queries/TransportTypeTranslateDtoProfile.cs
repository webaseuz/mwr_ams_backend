using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportTypeTranslateDtoProfile : Profile
{
    public TransportTypeTranslateDtoProfile()
    {
        CreateMap<TransportTypeTranslate, TransportTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class OilTypeTranslateDtoProfile : Profile
{
    public OilTypeTranslateDtoProfile()
    {
        CreateMap<OilTypeTranslate, OilTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

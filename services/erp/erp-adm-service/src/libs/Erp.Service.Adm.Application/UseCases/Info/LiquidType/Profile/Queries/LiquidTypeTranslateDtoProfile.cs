using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class LiquidTypeTranslateDtoProfile : Profile
{
    public LiquidTypeTranslateDtoProfile()
    {
        CreateMap<LiquidTypeTranslate, LiquidTypeTranslateDto>()
            .ForMember(src => src.Language, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

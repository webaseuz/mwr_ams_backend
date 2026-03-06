using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class BatteryTypeTranslateDtoProfile : Profile
{
    public BatteryTypeTranslateDtoProfile()
    {
        CreateMap<BatteryTypeTranslate, BatteryTypeTranslateDto>()
            .ForMember(src => src.Language, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}

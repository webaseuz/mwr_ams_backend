using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingLiquidDtoProfile : CultureProfile
{
    public TransportSettingLiquidDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingLiquid, TransportSettingLiquidDto>()
            .ForMember(src => src.LiquidTypeName, conf => conf.MapFrom(ent => ent.LiquidType.Translates.AsQueryable()
                .FirstOrDefault(LiquidTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.LiquidType.FullName));
    }
}

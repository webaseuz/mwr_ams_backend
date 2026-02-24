using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingLiquidDtoProfile : Profile
{
    public TransportSettingLiquidDtoProfile()
    {
        int lang = default;

        CreateMap<TransportSettingLiquid, TransportSettingLiquidDto>()
            .ForMember(src => src.LiquidTypeName, conf => conf.MapFrom(ent => ent.LiquidType.Translates.AsQueryable()
    .FirstOrDefault(LiquidTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.LiquidType.FullName));
    }
}

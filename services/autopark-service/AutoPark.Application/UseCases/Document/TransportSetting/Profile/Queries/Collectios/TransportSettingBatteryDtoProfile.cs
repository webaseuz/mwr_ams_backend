using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingBatteryDtoProfile : Profile
{
    public TransportSettingBatteryDtoProfile()
    {
        int lang = default;

        CreateMap<TransportSettingBattery, TransportSettingBatteryDto>()
            .ForMember(src => src.BatteryTypeName, conf => conf.MapFrom(ent => ent.BatteryType.Translates.AsQueryable()
                .FirstOrDefault(BatteryTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.BatteryType.FullName));
    }
}

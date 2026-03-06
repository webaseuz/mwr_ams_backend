using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingBatteryDtoProfile : CultureProfile
{
    public TransportSettingBatteryDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingBattery, TransportSettingBatteryDto>()
            .ForMember(src => src.BatteryTypeName, conf => conf.MapFrom(ent => ent.BatteryType.Translates.AsQueryable()
                .FirstOrDefault(BatteryTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.BatteryType.FullName));
    }
}

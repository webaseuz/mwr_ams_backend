using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingOilDtoProfile : CultureProfile
{
    public TransportSettingOilDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingOil, TransportSettingOilDto>()
            .ForMember(src => src.OilTypeName, conf => conf.MapFrom(ent => ent.OilType.Translates.AsQueryable()
                .FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.OilType.FullName))
            ;
    }
}

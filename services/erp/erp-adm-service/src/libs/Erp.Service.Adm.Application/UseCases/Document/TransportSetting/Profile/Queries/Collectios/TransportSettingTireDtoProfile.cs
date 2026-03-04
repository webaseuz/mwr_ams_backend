using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingTireDtoProfile : CultureProfile
{
    public TransportSettingTireDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingTire, TransportSettingTireDto>()
            .ForMember(src => src.TireModelName, conf => conf.MapFrom(ent => ent.TireModel.Translates.AsQueryable()
                .FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TireModel.FullName))
            .ForMember(src => src.Size, conf => conf.MapFrom(ent => $"{ent.TireSize.Height}/{ent.TireSize.Width} R{ent.TireSize.Radius}"));
    }
}

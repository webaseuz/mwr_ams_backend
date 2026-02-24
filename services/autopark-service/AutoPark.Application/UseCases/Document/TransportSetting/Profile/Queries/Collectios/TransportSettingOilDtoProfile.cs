using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingOilDtoProfile : Profile
{
    public TransportSettingOilDtoProfile()
    {

        int lang = default;

        CreateMap<TransportSettingOil, TransportSettingOilDto>()
            .ForMember(src => src.OilTypeName, conf => conf.MapFrom(ent => ent.OilType.Translates.AsQueryable()
                .FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.OilType.FullName))
            //.ForMember(src => src.OilModelName, conf => conf.MapFrom(ent => ent.OilModel.Translates.AsQueryable()
            //    .FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.OilType.FullName))
            ;
    }
}

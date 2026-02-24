using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelOilDtoProfile : Profile
{
    public TransportModelOilDtoProfile()
    {

        int lang = default;

        CreateMap<TransportModelOil, TransportModelOilDto>()
            .ForMember(src => src.OilModelName, conf => conf.MapFrom(ent => ent.OilModel.Translates.AsQueryable().FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.OilModel.ShortName))
            .ForMember(src => src.OilTypeName, conf => conf.MapFrom(ent => ent.OilType.Translates.AsQueryable().FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.OilType.ShortName));
    }
}

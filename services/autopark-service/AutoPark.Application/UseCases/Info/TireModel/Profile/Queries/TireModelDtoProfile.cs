using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class TireModelDtoProfile :
    Profile
{
    public TireModelDtoProfile()
    {
        int lang = default;

        CreateMap<TireModel, TireModelDto>()
         .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
         .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}

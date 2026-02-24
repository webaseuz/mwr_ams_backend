using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class OilModelBriefDtoProfile :
    Profile
{
    public OilModelBriefDtoProfile()
    {
        int lang = default;
        CreateMap<OilModel, OilModelBriefDto>()
         .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
         .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
         .ForMember(src => src.OilTypeName, conf => conf.MapFrom(ent => ent.OilType.Translates.AsQueryable().FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.OilType.FullName))
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
         ;
    }
}
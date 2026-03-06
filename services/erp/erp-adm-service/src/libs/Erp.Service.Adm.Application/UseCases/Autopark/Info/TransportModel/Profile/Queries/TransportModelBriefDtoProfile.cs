using Erp.Core.Service.Application;
using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportModelBriefDtoProfile : CultureProfile
{
    public TransportModelBriefDtoProfile()
    {
        var cultureId = 1;
        CreateMap<TransportModel, TransportModelBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FullName))
            .ForMember(src => src.TransportTypeName, conf => conf.MapFrom(ent => ent.TransportType.Translates.AsQueryable().FirstOrDefault(TransportTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportType.FullName))
            .ForMember(src => src.TransportBrandName, conf => conf.MapFrom(ent => ent.TransportBrand.Translates.AsQueryable().FirstOrDefault(TransportBrandTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportBrand.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName));
    }
}

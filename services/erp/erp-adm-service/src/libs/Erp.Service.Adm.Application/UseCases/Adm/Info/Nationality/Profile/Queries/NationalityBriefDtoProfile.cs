using Erp.Core.Service.Application;
using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using Erp.Core;

namespace Erp.Service.Adm.Application.UseCases;

public class NationalityBriefDtoProfile : CultureProfile
{
    public NationalityBriefDtoProfile()
    {
        var cultureId = 1;

        CreateMap<Nationality, NationalityBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(NationalityTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(NationalityTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName));
    }
}

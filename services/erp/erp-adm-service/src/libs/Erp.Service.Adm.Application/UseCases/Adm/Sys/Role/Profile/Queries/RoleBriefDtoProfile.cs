using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using Erp.Core;

namespace Erp.Service.Adm.Application.UseCases;

public class RoleBriefDtoProfile : CultureProfile
{
    public RoleBriefDtoProfile()
    {
        var cultureId = 1;
        CreateMap<Role, RoleBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FullName))
            .ForMember(src => src.State, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName));
    }
}

using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleBriefDtoProfile : Profile
{
    public RoleBriefDtoProfile()
    {
        int lang = default;
        CreateMap<Role, RoleBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}

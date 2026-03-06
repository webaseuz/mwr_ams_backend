using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class RoleDtoProfile : CultureProfile
{
    public RoleDtoProfile()
    {
        var cultureId = 1;
        CreateMap<Role, RoleDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FullName))
            .ForMember(src => src.State, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName))
            .ForMember(src => src.Permissions, conf => conf.MapFrom(ent => ent.RolePermissions.Where(x => !x.IsDeleted).Select(x => x.PermissionId)));
    }
}

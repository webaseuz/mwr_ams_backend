using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DepartmentBriefDtoProfile : CultureProfile
{
    public DepartmentBriefDtoProfile()
    {
        var cultureId = 1;

        CreateMap<Department, DepartmentBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
                .FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
                .FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));
    }
}

using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Departments;

public class DepartmentBriefDtoProfile : Profile
{
    public DepartmentBriefDtoProfile()
    {
        int lang = default;

        //DepartmentBriefDto
        CreateMap<Department, DepartmentBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName));

    }
}

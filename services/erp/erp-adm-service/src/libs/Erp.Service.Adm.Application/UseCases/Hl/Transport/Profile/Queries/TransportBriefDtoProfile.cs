using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportBriefDtoProfile : CultureProfile
{
    public TransportBriefDtoProfile()
    {
        var cultureId = 1;

        CreateMap<Transport, TransportBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName))
            .ForMember(src => src.DepartmentName, conf => conf.MapFrom(ent => ent.Department != null
                ? ent.Department.Translates.AsQueryable().FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Department.ShortName
                : null))
            .ForMember(src => src.TransportBrandName, conf => conf.MapFrom(ent => ent.TransportBrand.Translates.AsQueryable().FirstOrDefault(TransportBrandTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportBrand.ShortName))
            .ForMember(src => src.TransportColorName, conf => conf.MapFrom(ent => ent.TransportColor.Translates.AsQueryable().FirstOrDefault(TransportColorTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportColor.ShortName))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportModel.ShortName))
            .ForMember(src => src.TransportUseTypeName, conf => conf.MapFrom(ent => ent.TransportUseType.Translates.AsQueryable().FirstOrDefault(TransportUseTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.TransportUseType.ShortName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName));
    }
}

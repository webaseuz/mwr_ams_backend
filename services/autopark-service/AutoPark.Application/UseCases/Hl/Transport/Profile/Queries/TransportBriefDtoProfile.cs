using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class TransportBriefDtoProfile : Profile
{
    public TransportBriefDtoProfile()
    {
        int lang = default;

        CreateMap<Transport, TransportBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.DepartmentName, conf => conf.MapFrom(ent => ent.Department.Translates.AsQueryable().FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Department.ShortName))
            .ForMember(src => src.TransportBrandName, conf => conf.MapFrom(ent => ent.TransportBrand.Translates.AsQueryable().FirstOrDefault(TransportBrandTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.TransportBrand.ShortName))
            .ForMember(src => src.TransportColorName, conf => conf.MapFrom(ent => ent.TransportColor.Translates.AsQueryable().FirstOrDefault(TransportColorTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.TransportColor.ShortName))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.TransportModel.ShortName))
            .ForMember(src => src.TransportUseTypeName, conf => conf.MapFrom(ent => ent.TransportUseType.Translates.AsQueryable().FirstOrDefault(TransportUseTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.TransportUseType.ShortName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
            ;

    }
}

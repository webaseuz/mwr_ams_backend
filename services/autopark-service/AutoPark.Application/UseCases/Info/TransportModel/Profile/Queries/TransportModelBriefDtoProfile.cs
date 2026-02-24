using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelBriefDtoProfile :
    Profile
{
    public TransportModelBriefDtoProfile()
    {
        int lang = default;

        CreateMap<TransportModel, TransportModelBriefDto>()
         //.ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
         .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
         .ForMember(src => src.TransportTypeName, conf => conf.MapFrom(ent => ent.TransportType.Translates.AsQueryable().FirstOrDefault(TransportTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.TransportType.FullName))
         .ForMember(src => src.TransportBrandName, conf => conf.MapFrom(ent => ent.TransportBrand.Translates.AsQueryable().FirstOrDefault(TransportBrandTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.TransportBrand.FullName))
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));

        CreateMap<TransportModelFile, TransportModelFileDto>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}

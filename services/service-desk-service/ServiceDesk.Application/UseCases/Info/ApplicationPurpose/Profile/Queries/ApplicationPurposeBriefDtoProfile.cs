using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

class ApplicationPurposeBriefDtoProfile : Profile
{
    public ApplicationPurposeBriefDtoProfile()
    {
        int lang = default;
        CreateMap<ApplicationPurpose, ApplicationPurposeBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
            .FirstOrDefault(ApplicationPurposeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
            .FirstOrDefault(ApplicationPurposeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            .ForMember(src => src.DeviceTypeName, conf => conf.MapFrom(ent => ent.DeviceType.Translates.AsQueryable()
            .FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DeviceType.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
            .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}

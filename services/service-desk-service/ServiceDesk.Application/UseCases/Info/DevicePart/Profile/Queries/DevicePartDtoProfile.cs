using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DevicePartDtoProfile : Profile
{
    public DevicePartDtoProfile()
    {
        int lang = default;

        CreateMap<DevicePart, DevicePartDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(DevicePartTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(DevicePartTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            .ForMember(src => src.DeviceTypeName, conf => conf.MapFrom(ent => ent.DeviceType.Translates.AsQueryable().FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DeviceType.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}

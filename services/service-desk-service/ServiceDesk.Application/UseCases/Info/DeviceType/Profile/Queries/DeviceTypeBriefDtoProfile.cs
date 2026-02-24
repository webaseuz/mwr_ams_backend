using AutoMapper;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeBriefDtoProfile : Profile
{
    public DeviceTypeBriefDtoProfile()
    {
        int lang = default;
        CreateMap<DeviceType, DeviceTypeBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
            .FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
            .FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            //.ForMember(src => src.BaseDeviceTypeName, conf => conf.MapFrom(ent => ent.BaseDeviceTypeId))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
            .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));

    }
}

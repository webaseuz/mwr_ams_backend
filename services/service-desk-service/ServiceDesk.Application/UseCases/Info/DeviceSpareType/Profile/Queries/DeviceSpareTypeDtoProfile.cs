using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeDtoProfile : Profile
{
    public DeviceSpareTypeDtoProfile()
    {
        int lang = default;

        CreateMap<DeviceSpareType, DeviceSpareTypeDto>()
			.ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
			.FirstOrDefault(DeviceSpareTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
			.ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable()
			.FirstOrDefault(DeviceSpareTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
			.ForMember(src => src.DeviceTypeName, conf => conf.MapFrom(ent => ent.DeviceType.Translates.AsQueryable()
			.FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DeviceType.FullName))
			.ForMember(src => src.DevicePartName, conf => conf.MapFrom(ent => ent.DevicePart.Translates.AsQueryable()
			.FirstOrDefault(DevicePartTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DevicePart.FullName))
			.ForMember(src => src.DeviceModelName, conf => conf.MapFrom(ent => ent.DeviceModel.Translates.AsQueryable()
			.FirstOrDefault(DeviceModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DeviceModel.FullName))
			.ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
			.FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
	}
}

using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionDtoProfile : Profile
{
    public RegionDtoProfile()
    {
		int lang = default;

		CreateMap<Region, RegionDto>()
		 .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
		 .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
		 .ForMember(src => src.Country, conf => conf.MapFrom(ent => ent.Country))
		 .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}

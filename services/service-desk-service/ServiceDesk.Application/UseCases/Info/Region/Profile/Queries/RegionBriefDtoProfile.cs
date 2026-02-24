using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionBriefDtoProfile : 
	Profile
{
    public RegionBriefDtoProfile()
    {
		int lang = default;

		CreateMap<Region, RegionBriefDto>()
		 .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
		 .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
		 .ForMember(src => src.CountryName, conf => conf.MapFrom(ent => ent.Country.Translates.AsQueryable().FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Country.FullName))
		 .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}
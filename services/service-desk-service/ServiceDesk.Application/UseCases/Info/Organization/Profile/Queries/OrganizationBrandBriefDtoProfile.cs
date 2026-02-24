using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationBriefDtoProfile : 
	Profile
{
    public OrganizationBriefDtoProfile()
    {
		int lang = default;

		CreateMap<Organization, OrganizationBriefDto>()
		 .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
		 .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
		 .ForMember(src => src.CountryName, conf => conf.MapFrom(ent => ent.Country.Translates.AsQueryable().FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Country.FullName))
		 .ForMember(src => src.DistrictName, conf => conf.MapFrom(ent => ent.District.Translates.AsQueryable().FirstOrDefault(DistrictTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.District.FullName))
		 .ForMember(src => src.RegionName, conf => conf.MapFrom(ent => ent.Region.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Region.FullName))
		 .ForMember(src => src.ParentName, conf => conf.MapFrom(ent => ent.Parent.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Parent.FullName))
		 .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
		 ;
	}
}
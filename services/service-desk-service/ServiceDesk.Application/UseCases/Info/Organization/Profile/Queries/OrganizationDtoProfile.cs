using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationDtoProfile :
	Profile
{
    public OrganizationDtoProfile()
    {
		int lang = default;

		CreateMap<Organization, OrganizationDto>()
		 .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
		 .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
		 .ForMember(src => src.Parent, conf => conf.MapFrom(ent => ent.Parent))
		 .ForMember(src => src.Country, conf => conf.MapFrom(ent => ent.Country))
		 .ForMember(src => src.District, conf => conf.MapFrom(ent => ent.District))
		 .ForMember(src => src.Region, conf => conf.MapFrom(ent => ent.Region.Translates.AsQueryable().FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
		 .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
	}
}

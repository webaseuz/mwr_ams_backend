using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Drivers;

class DriverBriefDtoProfile :
    Profile
{
    public DriverBriefDtoProfile()
    {
        int lang = default;
        CreateMap<Driver, DriverBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName))
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
        ;
    }
}

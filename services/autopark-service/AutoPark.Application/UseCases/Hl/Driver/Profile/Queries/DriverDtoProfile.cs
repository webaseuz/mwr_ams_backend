using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Drivers;

class DriverDtoProfile :
    Profile
{
    public DriverDtoProfile()
    {
        int lang = default;
        CreateMap<Driver, DriverDto>()
            .ForMember(src => src.Inn, conf => conf.MapFrom(ent => ent.Person.Inn))
            .ForMember(src => src.Pinfl, conf => conf.MapFrom(ent => ent.Person.Pinfl))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.PersonName, conf => conf.MapFrom(ent => ent.Person.Pinfl + " - " + ent.Person.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
        ;
    }
}

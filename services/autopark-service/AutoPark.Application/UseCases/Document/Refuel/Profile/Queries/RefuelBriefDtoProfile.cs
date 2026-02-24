using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class RefuelBriefDtoProfile :
    Profile
{
    public RefuelBriefDtoProfile()
    {
        int lang = default;

        CreateMap<Refuel, RefuelBriefDto>()
            .ForMember(src => src.FuelTypeName, conf => conf.MapFrom(ent => ent.FuelType.Translates.AsQueryable()
            .FirstOrDefault(FuelTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.FuelType.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FullName))
            .ForMember(src => src.FuelCardNumber, conf => conf.MapFrom(ent => ent.FuelCard.CardNumber))
            .ForMember(scr => scr.TransportName, conf => conf.MapFrom(ent => $"{ent.Transport.StateCode} {ent.Transport.StateNumber}"))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
            .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.PersonId, conf => conf.MapFrom(ent => ent.Driver.PersonId))
            .ForMember(src => src.TotalPrice, conf => conf.MapFrom(ent => ent.Litre * ent.LitrePrice))
            ;
    }
}
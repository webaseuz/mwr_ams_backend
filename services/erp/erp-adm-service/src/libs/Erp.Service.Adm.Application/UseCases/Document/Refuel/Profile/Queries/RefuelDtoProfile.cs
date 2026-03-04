using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class RefuelDtoProfile : CultureProfile
{
    public RefuelDtoProfile()
    {
        var cultureId = 1;

        CreateMap<Refuel, RefuelDto>()
            .ForMember(src => src.FuelTypeName, conf => conf.MapFrom(ent => ent.FuelType.Translates.AsQueryable()
                .FirstOrDefault(FuelTypeTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.FuelType.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.FuelCardNumber, conf => conf.MapFrom(ent => ent.FuelCard.CardNumber))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FullName))
            .ForMember(src => src.TransportName, conf => conf.MapFrom(ent => $"{ent.Transport.StateCode} {ent.Transport.StateNumber}"))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.TotalPrice, conf => conf.MapFrom(ent => ent.Litre * ent.LitrePrice))
            .ForMember(src => src.CanCreateForAllBranch, conf => conf.Ignore())
            ;
    }
}

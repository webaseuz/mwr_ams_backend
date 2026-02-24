using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;
using System.Linq.Dynamic.Core;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingDtoProfile : Profile
{
    public TransportSettingDtoProfile()
    {
        int lang = default;
        CreateMap<TransportSetting, TransportSettingDto>()
            .ForMember(scr => scr.Batteries, conf => conf.MapFrom(ent => ent.Batteries))
            .ForMember(scr => scr.Fuels, conf => conf.MapFrom(ent => ent.Fuels))
            .ForMember(scr => scr.Inspections, conf => conf.MapFrom(ent => ent.Inspections))
            .ForMember(scr => scr.Insurances, conf => conf.MapFrom(ent => ent.Insurances))
            .ForMember(scr => scr.Liquids, conf => conf.MapFrom(ent => ent.Liquids))
            .ForMember(scr => scr.Oils, conf => conf.MapFrom(ent => ent.Oils))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.ManagerFullName, conf => conf.MapFrom(ent => ent.Manager.FullName))
            .ForMember(scr => scr.Tires, conf => conf.MapFrom(ent => ent.Tires))
            .ForMember(scr => scr.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
            .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
            .ForMember(scr => scr.TransportName, conf => conf.MapFrom(ent => $"{ent.Transport.StateCode} {ent.Transport.StateNumber}"))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.Pinfl + " - " + ent.Driver.Person.FullName))
            .ForMember(scr => scr.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.Transport.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.Transport.TransportModel.ShortName))
            .ForMember(src => src.TransportModelId, conf => conf.MapFrom(ent => ent.Transport.TransportModelId))
            .ForMember(src => src.TransportColorId, conf => conf.MapFrom(ent => ent.Transport.TransportColorId))
            .ForMember(src => src.TransportColorName, conf => conf.MapFrom(ent => ent.Transport.TransportColor.Translates.AsQueryable().FirstOrDefault(TransportColorTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Transport.TransportColor.ShortName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId));
    }
}

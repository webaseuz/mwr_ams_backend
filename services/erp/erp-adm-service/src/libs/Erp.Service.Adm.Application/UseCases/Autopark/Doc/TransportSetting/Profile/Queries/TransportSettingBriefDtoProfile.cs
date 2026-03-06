using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingBriefDtoProfile : CultureProfile
{
    public TransportSettingBriefDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSetting, TransportSettingBriefDto>()
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.TransportName, conf => conf.MapFrom(ent => ent.Transport.StateCode + " " + ent.Transport.StateNumber))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.Pinfl + " - " + ent.Driver.Person.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.Transport.TransportModel.Translates.AsQueryable()
                .FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, cultureId)).TranslateText ?? ent.Transport.TransportModel.ShortName))
            .ForMember(src => src.ManagerFullName, conf => conf.MapFrom(ent => ent.Manager.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))
            .ForMember(src => src.CanAccept, conf => conf.Ignore())
            .ForMember(src => src.CanModify, conf => conf.Ignore())
            .ForMember(src => src.CanDelete, conf => conf.Ignore())
            .ForMember(src => src.CanCancel, conf => conf.Ignore())
            .ForMember(src => src.FuelCardNumber, conf => conf.Ignore())
            ;
    }
}
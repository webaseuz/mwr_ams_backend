using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingBriefDtoProfile : Profile
{
    public TransportSettingBriefDtoProfile()
    {
        int lang = default;
        CreateMap<TransportSetting, TransportSettingBriefDto>()
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.TransportName, conf => conf.MapFrom(ent => ent.Transport.StateCode + " " + ent.Transport.StateNumber))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.Pinfl + " - " + ent.Driver.Person.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName))
            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.Transport.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.Transport.TransportModel.ShortName))
            .ForMember(src => src.ManagerFullName, conf => conf.MapFrom(ent => ent.Manager.FullName))
            .ForMember(src => src.OrganizationId, conf => conf.MapFrom(ent => ent.Branch.OrganizationId))

            ;
    }
}
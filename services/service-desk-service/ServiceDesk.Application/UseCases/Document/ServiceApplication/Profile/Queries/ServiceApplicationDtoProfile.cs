using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationDtoProfile : Profile
{
	public ServiceApplicationDtoProfile()
	{
        int lang = default;

        CreateMap<ServiceApplication, ServiceApplicationDto>()
                 .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                    .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
                .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
                .ForMember(src => src.DeviceTypeName, conf => conf.MapFrom(ent => ent.DeviceType.Translates.AsQueryable()
                    .FirstOrDefault(DeviceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DeviceType.FullName))
                .ForMember(src => src.DeviceModelName, conf => conf.MapFrom(ent => ent.Device.DeviceModel.Translates.AsQueryable()
                    .FirstOrDefault(DeviceModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Device.DeviceModel.FullName))
                .ForMember(src => src.ExecutorTypeName, conf => conf.MapFrom(ent => ent.ExecutorType.Translates.AsQueryable()
                    .FirstOrDefault(ExecutorTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.ExecutorType.FullName))
                .ForMember(src => src.ServiceContractorName, conf => conf.MapFrom(ent => ent.ServiceContractor.FullName))
                .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName))
                .ForMember(src => src.DeviceName, conf => conf.MapFrom(ent => $"{ent.Device.DeviceModel.FullName} - {ent.Device.UniqueNumber}"))
                .ForMember(src => src.Parts, conf => conf.MapFrom(ent => ent.ServiceApplicationParts))
                .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.ServiceApplicationFiles))
                .ForMember(src => src.Spares, conf => conf.MapFrom(ent => ent.ServiceApplicationSpares))
                .ForMember(src => src.ExecutorFiles, conf => conf.MapFrom(ent => ent.ServiceApplicationExecutorFiles))
                .ForMember(src => src.SerialNumber,conf => conf.MapFrom(ent => ent.Device.SerialNumber));
    }
}

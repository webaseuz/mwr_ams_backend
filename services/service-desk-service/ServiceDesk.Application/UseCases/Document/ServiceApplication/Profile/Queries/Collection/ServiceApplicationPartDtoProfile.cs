using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationPartDtoProfile : Profile
{
	public ServiceApplicationPartDtoProfile()
	{
        int lang = default;

        CreateMap<ServiceApplicationPart, ServiceApplicationPartDto>()
            .ForMember(src => src.ApplicationPurposeName, conf => conf.MapFrom(ent => ent.ApplicationPurpose.Translates.AsQueryable()
            .FirstOrDefault(ApplicationPurposeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.ApplicationPurpose.FullName))
            .ForMember(src => src.DevicePartName, conf => conf.MapFrom(ent => ent.DevicePart.Translates.AsQueryable()
            .FirstOrDefault(DevicePartTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.DevicePart.FullName))
            .ForMember(src => src.ServiceTypeName, conf => conf.MapFrom(ent => ent.ServiceType.Translates.AsQueryable()
            .FirstOrDefault(ServiceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.ServiceType.FullName))
            ;
    }
}

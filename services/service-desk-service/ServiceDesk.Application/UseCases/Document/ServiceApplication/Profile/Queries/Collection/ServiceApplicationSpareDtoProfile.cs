using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationSpareDtoProfile : Profile
{
	public ServiceApplicationSpareDtoProfile()
	{
        CreateMap<ServiceApplicationSpare, ServiceApplicationSpareDto>()
            .ForMember(src => src.DeviceSpareTypeName, conf => conf.MapFrom(ent => ent.DeviceSpareType.FullName))
            .ForMember(src => src.Nomenclature,conf => conf.MapFrom(ent => ent.DeviceSpareType.Nomenclature));
    }
}

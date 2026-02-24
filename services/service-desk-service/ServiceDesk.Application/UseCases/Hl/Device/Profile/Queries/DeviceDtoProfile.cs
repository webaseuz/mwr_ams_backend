using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceDtoProfile : Profile
{
	public DeviceDtoProfile()
	{
		//DeviceDto
		CreateMap<Device, DeviceDto>()
			.ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));
	}
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceFileDtoProfile : Profile
{
	public DeviceFileDtoProfile()
	{
		CreateMap<DeviceFile, DeviceFileDto>();
	}
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceCommandProfile : Profile
{
	public UpdateDeviceCommandProfile()
	{
		CreateMap<UpdateDeviceCommand, Device>()
			.ForMember(src => src.Files, conf => conf.Ignore());
	}
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceCommandProfile : Profile
{
	public CreateDeviceCommandProfile()
	{
		CreateMap<CreateDeviceCommand, Device>()
			.ForMember(src => src.Files, conf => conf.Ignore());
	}
}

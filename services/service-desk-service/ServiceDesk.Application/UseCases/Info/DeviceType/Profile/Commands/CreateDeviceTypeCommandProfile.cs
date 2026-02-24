using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class CreateDeviceTypeCommandProfile : Profile
{
    public CreateDeviceTypeCommandProfile()
    {
        CreateMap<CreateDeviceTypeCommand, DeviceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

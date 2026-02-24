using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class CreateDeviceSpareTypeCommandProfile : Profile
{
    public CreateDeviceSpareTypeCommandProfile()
    {
        CreateMap<CreateDeviceSpareTypeCommand, DeviceSpareType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

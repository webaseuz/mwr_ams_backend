using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class UpdateDeviceSpareTypeCommandProfile : Profile
{
    public UpdateDeviceSpareTypeCommandProfile()
    {
        CreateMap<UpdateDeviceSpareTypeCommand, DeviceSpareType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

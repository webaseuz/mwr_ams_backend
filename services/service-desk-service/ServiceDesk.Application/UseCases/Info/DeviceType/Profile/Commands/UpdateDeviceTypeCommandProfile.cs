using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class UpdateDeviceTypeCommandProfile : Profile
{
    public UpdateDeviceTypeCommandProfile()
    {
        CreateMap<UpdateDeviceTypeCommand, DeviceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class UpdateDevicePartCommandProfile : Profile
{
    public UpdateDevicePartCommandProfile()
    {
        CreateMap<UpdateDevicePartCommand, DevicePart>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

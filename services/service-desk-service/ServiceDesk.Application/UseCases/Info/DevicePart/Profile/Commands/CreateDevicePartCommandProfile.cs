using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class CreateDevicePartCommandProfile : Profile
{
    public CreateDevicePartCommandProfile()
    {
        CreateMap<CreateDevicePartCommand, DevicePart>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

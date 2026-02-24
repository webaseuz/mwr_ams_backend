using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class CreateDeviceModelCommandProfile : Profile
{
    public CreateDeviceModelCommandProfile()
    {
        CreateMap<CreateDeviceModelCommand, DeviceModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

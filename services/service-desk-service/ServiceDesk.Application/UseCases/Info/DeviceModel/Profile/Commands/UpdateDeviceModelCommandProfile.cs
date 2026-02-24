using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class UpdateDeviceModelCommandProfile : Profile
{
    public UpdateDeviceModelCommandProfile()
    {
        CreateMap<UpdateDeviceModelCommand, DeviceModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

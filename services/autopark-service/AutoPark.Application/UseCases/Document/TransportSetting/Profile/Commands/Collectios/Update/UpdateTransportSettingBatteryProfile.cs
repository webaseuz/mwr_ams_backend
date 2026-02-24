using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingBatteryProfile : Profile
{
    public UpdateTransportSettingBatteryProfile()
    {
        CreateMap<UpdateTransportSettingBatteryCommand, TransportSettingBattery>();
    }
}

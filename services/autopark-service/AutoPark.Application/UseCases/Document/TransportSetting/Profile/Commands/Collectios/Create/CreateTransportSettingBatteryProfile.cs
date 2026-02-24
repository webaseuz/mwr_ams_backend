using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingBatteryProfile : Profile
{
    public CreateTransportSettingBatteryProfile()
    {
        CreateMap<CreateTransportSettingBatteryCommand, TransportSettingBattery>();
    }
}

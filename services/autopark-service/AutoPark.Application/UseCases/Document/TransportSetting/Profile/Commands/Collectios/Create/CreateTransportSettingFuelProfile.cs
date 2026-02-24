using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingFuelProfile : Profile
{
    public CreateTransportSettingFuelProfile()
    {
        CreateMap<CreateTransportSettingFuelCommand, TransportSettingFuel>();
    }
}

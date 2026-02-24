using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingFuelProfile : Profile
{
    public UpdateTransportSettingFuelProfile()
    {
        CreateMap<UpdateTransportSettingFuelCommand, TransportSettingFuel>();
    }
}

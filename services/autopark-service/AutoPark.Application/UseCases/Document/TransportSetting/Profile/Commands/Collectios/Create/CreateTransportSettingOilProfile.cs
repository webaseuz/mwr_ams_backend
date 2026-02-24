using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingOilProfile : Profile
{
    public CreateTransportSettingOilProfile()
    {
        CreateMap<CreateTransportSettingOilCommand, TransportSettingOil>();
    }
}

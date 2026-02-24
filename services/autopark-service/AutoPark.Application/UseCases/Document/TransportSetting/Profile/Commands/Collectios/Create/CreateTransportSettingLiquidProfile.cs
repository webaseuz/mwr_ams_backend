using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingLiquidProfile : Profile
{
    public CreateTransportSettingLiquidProfile()
    {
        CreateMap<CreateTransportSettingLiquidCommand, TransportSettingLiquid>();
    }
}

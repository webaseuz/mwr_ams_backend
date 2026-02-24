using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingLiquidProfile : Profile
{
    public UpdateTransportSettingLiquidProfile()
    {
        CreateMap<UpdateTransportSettingLiquidCommand, TransportSettingLiquid>();
    }
}

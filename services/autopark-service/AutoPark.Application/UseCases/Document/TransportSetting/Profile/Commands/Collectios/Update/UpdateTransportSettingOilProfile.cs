using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingOilProfile : Profile
{
    public UpdateTransportSettingOilProfile()
    {
        CreateMap<UpdateTransportSettingOilCommand, TransportSettingOil>();
    }
}

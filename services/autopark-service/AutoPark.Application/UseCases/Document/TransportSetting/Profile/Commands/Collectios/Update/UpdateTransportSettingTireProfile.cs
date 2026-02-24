using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingTireProfile : Profile
{
    public UpdateTransportSettingTireProfile()
    {
        CreateMap<UpdateTransportSettingTireCommand, TransportSettingTire>();
    }
}

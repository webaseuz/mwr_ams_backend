using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingTireProfile : Profile
{
    public CreateTransportSettingTireProfile()
    {
        CreateMap<CreateTransportSettingTireCommand, TransportSettingTire>();
    }
}

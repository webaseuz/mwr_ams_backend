using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingInspectionProfile : Profile
{
    public CreateTransportSettingInspectionProfile()
    {
        CreateMap<CreateTransportSettingInspectionCommand, TransportSettingInspection>();
    }
}

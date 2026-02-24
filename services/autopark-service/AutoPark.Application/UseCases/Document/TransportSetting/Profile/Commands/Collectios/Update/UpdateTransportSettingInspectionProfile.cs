using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingInspectionProfile : Profile
{
    public UpdateTransportSettingInspectionProfile()
    {
        CreateMap<UpdateTransportSettingInspectionCommand, TransportSettingInspection>();
    }
}

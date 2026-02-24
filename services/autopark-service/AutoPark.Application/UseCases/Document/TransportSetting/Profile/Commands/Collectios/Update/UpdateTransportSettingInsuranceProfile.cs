using AutoMapper;
namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingInsuranceProfile : Profile
{
    public UpdateTransportSettingInsuranceProfile()
    {
        CreateMap<UpdateTransportSettingInsuranceCommand, TransportSettingInsurance>();
    }
}

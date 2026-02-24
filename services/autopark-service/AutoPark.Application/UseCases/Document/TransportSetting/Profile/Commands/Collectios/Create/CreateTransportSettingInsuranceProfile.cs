using AutoMapper;
namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingInsuranceProfile : Profile
{
    public CreateTransportSettingInsuranceProfile()
    {
        CreateMap<CreateTransportSettingInsuranceCommand, TransportSettingInsurance>();
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class CreateInsuranceTypeCommandProfile : Profile
{
    public CreateInsuranceTypeCommandProfile()
    {
        CreateMap<CreateInsuranceTypeCommand, InsuranceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

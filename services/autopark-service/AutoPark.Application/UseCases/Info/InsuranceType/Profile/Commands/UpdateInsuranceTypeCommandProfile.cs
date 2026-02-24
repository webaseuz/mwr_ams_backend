using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class UpdateInsuranceTypeCommandProfile : Profile
{
    public UpdateInsuranceTypeCommandProfile()
    {
        CreateMap<UpdateInsuranceTypeCommand, InsuranceType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}


using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class InsuranceTypeTranslateCommandProfile : Profile
{
    public InsuranceTypeTranslateCommandProfile()
    {
        CreateMap<InsuranceTypeTranslateCommand, InsuranceTypeTranslate>();
    }
}
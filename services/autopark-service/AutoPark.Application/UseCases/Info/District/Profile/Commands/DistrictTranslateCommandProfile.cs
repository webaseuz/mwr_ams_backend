using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Districts;

public class DistrictTranslateCommandProfile : Profile
{
    public DistrictTranslateCommandProfile()
    {
        CreateMap<DistrictTranslateCommand, DistrictTranslate>();
    }
}

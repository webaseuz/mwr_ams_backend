using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Districts;

public class DistrictTranslateCommandProfile : Profile
{
    public DistrictTranslateCommandProfile()
    {
        CreateMap<DistrictTranslateCommand, DistrictTranslate>();
    }
}

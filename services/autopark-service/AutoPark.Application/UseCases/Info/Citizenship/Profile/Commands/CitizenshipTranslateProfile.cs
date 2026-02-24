using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Citizenships;

public class CitizenshipTranslateProfile : Profile
{
    public CitizenshipTranslateProfile()
    {
        CreateMap<CitizenshipTranslateCommand, CitizenshipTranslate>();
    }
}
using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Countries;

public class CountryTranslateCommandProfile : Profile
{
    public CountryTranslateCommandProfile()
    {
        CreateMap<CountryTranslateCommand, CountryTranslate>();
    }
}

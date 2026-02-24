using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class CountryTranslateCommandProfile : Profile
{
    public CountryTranslateCommandProfile()
    {
        CreateMap<CountryTranslateCommand, CountryTranslate>();
    }
}

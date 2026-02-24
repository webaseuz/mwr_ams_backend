using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipTranslateProfile : Profile
{
    public CitizenshipTranslateProfile()
    {
        CreateMap<CitizenshipTranslateCommand, CitizenshipTranslate>();
    }
}
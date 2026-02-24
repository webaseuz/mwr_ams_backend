using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Nationalities;

public class NationalityTranslateCommandProfile : Profile
{
    public NationalityTranslateCommandProfile()
    {
        CreateMap<NationalityTranslateCommand, NationalityTranslate>();
    }
}

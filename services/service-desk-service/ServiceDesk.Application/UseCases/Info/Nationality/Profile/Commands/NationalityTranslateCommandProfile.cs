using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class NationalityTranslateCommandProfile : Profile
{
    public NationalityTranslateCommandProfile()
    {
        CreateMap<NationalityTranslateCommand, NationalityTranslate>();
    }
}

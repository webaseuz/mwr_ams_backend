using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class TireModelTranslateCommandProfile :
    Profile
{
    public TireModelTranslateCommandProfile()
    {
        CreateMap<TireModelTranslateCommand, TireModelTranslate>();
    }
}

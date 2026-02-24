using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class OilModelTranslateCommandProfile :
    Profile
{
    public OilModelTranslateCommandProfile()
    {
        CreateMap<OilModelTranslateCommand, OilModelTranslate>();
    }
}

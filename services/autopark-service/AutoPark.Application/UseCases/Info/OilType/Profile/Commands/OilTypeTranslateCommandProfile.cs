using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilTypes;

public class OilTypeTranslateCommandProfile :
    Profile
{
    public OilTypeTranslateCommandProfile()
    {
        CreateMap<OilTypeTranslateCommand, OilTypeTranslate>();
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportColors;

public class TransportColorTranslateCommandProfile :
    Profile
{
    public TransportColorTranslateCommandProfile()
    {
        CreateMap<TransportColorTranslateCommand, TransportColorTranslate>();
    }
}

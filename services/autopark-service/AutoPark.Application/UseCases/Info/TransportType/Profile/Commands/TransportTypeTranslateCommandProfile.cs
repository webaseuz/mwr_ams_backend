using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportTypes;

public class TransportTypeTranslateCommandProfile :
    Profile
{
    public TransportTypeTranslateCommandProfile()
    {
        CreateMap<TransportTypeTranslateCommand, TransportTypeTranslate>();
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class TransportUseTypeTranslateCommandProfile :
    Profile
{
    public TransportUseTypeTranslateCommandProfile()
    {
        CreateMap<TransportUseTypeTranslateCommand, TransportUseTypeTranslate>();
    }
}

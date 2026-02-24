using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelTranslateCommandProfile :
    Profile
{
    public TransportModelTranslateCommandProfile()
    {
        CreateMap<TransportModelTranslateCommand, TransportModelTranslate>();
    }
}

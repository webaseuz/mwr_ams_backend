using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportBrands;

public class TransportBrandTranslateCommandProfile :
    Profile
{
    public TransportBrandTranslateCommandProfile()
    {
        CreateMap<TransportBrandTranslateCommand, TransportBrandTranslate>();
    }
}

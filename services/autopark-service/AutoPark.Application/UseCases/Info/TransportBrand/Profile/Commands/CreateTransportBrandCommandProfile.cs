using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportBrands;

public class CreateTransportBrandCommandProfile :
    Profile
{
    public CreateTransportBrandCommandProfile()
    {
        CreateMap<CreateTransportBrandCommand, TransportBrand>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

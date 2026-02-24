using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportBrands;

public class UpdateTransportBrandCommandProfile :
    Profile
{
    public UpdateTransportBrandCommandProfile()
    {
        CreateMap<UpdateTransportBrandCommand, TransportBrand>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

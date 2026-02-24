using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportColors;

public class CreateTransportColorCommandProfile :
    Profile
{
    public CreateTransportColorCommandProfile()
    {
        CreateMap<CreateTransportColorCommand, TransportColor>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

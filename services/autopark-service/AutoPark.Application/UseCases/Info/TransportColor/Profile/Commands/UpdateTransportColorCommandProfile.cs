using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportColors;

public class UpdateTransportColorCommandProfile :
    Profile
{
    public UpdateTransportColorCommandProfile()
    {
        CreateMap<UpdateTransportColorCommand, TransportColor>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

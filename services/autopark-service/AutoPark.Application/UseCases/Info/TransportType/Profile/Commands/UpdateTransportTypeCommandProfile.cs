using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportTypes;

public class UpdateTransportTypeCommandProfile :
    Profile
{
    public UpdateTransportTypeCommandProfile()
    {
        CreateMap<UpdateTransportTypeCommand, TransportType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

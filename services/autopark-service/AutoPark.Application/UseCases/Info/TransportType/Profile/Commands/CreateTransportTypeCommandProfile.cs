using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportTypes;

public class CreateTransportTypeCommandProfile :
    Profile
{
    public CreateTransportTypeCommandProfile()
    {
        CreateMap<CreateTransportTypeCommand, TransportType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

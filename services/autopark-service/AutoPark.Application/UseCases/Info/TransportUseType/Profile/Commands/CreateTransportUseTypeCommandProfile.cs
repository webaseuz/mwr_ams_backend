using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class CreateTransportUseTypeCommandProfile :
    Profile
{
    public CreateTransportUseTypeCommandProfile()
    {
        CreateMap<CreateTransportUseTypeCommand, TransportUseType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}

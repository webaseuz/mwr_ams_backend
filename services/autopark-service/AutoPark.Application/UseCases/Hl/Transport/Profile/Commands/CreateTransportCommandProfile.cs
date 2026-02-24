using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class CreateTransportCommandProfile :
    Profile
{
    public CreateTransportCommandProfile()
    {
        CreateMap<CreateTransportCommand, Transport>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}

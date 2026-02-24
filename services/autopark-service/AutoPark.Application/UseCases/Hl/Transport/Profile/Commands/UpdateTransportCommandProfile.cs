using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class UpdateTransportCommandProfile :
    Profile
{
    public UpdateTransportCommandProfile()
    {
        CreateMap<UpdateTransportCommand, Transport>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}

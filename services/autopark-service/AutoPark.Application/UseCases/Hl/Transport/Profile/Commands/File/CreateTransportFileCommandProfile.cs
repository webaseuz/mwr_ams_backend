using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class CreateTransportFileCommandProfile :
    Profile
{
    public CreateTransportFileCommandProfile()
    {
        CreateMap<CreateTransportFileCommand, TransportFile>();
    }
}

using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class UpdateTransportFileCommandProfile :
    Profile
{
    public UpdateTransportFileCommandProfile()
    {
        CreateMap<UpdateTransportFileCommand, TransportFile>();
    }
}

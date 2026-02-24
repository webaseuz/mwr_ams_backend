using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class TransportFileDtoProfile :
    Profile
{
    public TransportFileDtoProfile()
    {
        CreateMap<TransportFile, TransportFileDto>();
    }
}

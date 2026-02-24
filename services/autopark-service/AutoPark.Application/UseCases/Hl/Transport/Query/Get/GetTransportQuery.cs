using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportQuery :
    IRequest<TransportDto>
{
}

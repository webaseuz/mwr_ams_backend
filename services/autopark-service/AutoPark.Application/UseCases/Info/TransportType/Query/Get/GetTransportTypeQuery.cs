using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeQuery :
    IRequest<TransportTypeDto>
{
}

using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeQuery :
    IRequest<TransportUseTypeDto>
{
}

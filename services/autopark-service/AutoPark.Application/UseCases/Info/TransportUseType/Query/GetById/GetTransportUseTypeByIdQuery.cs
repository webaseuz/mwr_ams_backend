using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeByIdQuery :
    IRequest<TransportUseTypeDto>
{
    public int Id { get; set; }
}

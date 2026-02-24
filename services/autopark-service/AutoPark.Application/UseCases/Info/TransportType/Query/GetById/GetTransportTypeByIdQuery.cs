using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeByIdQuery :
    IRequest<TransportTypeDto>
{
    public int Id { get; set; }
}

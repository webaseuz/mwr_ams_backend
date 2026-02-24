using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportByIdQuery :
    IRequest<TransportDto>
{
    public int Id { get; set; }
}

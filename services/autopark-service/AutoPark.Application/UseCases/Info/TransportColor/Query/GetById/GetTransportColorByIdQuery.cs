using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorByIdQuery :
    IRequest<TransportColorDto>
{
    public int Id { get; set; }
}

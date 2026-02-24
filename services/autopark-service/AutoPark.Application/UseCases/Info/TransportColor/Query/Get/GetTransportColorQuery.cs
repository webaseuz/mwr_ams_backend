using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorQuery :
    IRequest<TransportColorDto>
{
}

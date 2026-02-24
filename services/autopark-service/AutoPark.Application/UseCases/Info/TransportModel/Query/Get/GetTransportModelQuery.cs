using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelQuery :
    IRequest<TransportModelDto>
{
}

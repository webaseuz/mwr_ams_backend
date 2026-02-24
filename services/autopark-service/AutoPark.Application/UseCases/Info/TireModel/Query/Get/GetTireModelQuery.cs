using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelQuery :
    IRequest<TireModelDto>
{
}

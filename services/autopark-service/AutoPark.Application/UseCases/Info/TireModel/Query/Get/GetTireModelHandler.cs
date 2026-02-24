using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelHandler :
    IRequestHandler<GetTireModelQuery, TireModelDto>
{
    public Task<TireModelDto> Handle(
        GetTireModelQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TireModelDto());
}

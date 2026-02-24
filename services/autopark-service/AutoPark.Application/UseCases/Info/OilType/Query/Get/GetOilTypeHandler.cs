using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeHandler :
    IRequestHandler<GetOilTypeQuery, OilTypeDto>
{
    public Task<OilTypeDto> Handle(
        GetOilTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new OilTypeDto());
}

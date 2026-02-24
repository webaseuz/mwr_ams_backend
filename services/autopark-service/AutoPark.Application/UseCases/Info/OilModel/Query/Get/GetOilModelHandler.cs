using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelHandler :
    IRequestHandler<GetOilModelQuery, OilModelDto>
{
    public Task<OilModelDto> Handle(
        GetOilModelQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new OilModelDto());
}

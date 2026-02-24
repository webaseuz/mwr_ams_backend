using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class GetDistrictQueryHandler :
    IRequestHandler<GetDistrictQuery, DistrictDto>
{
    public Task<DistrictDto> Handle(
        GetDistrictQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DistrictDto());
}

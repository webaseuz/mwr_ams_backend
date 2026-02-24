using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoQueryHandler :
    IRequestHandler<GetPresentTrackingInfoQuery, PresentTrackingInfoDto>
{
    public Task<PresentTrackingInfoDto> Handle(
        GetPresentTrackingInfoQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new PresentTrackingInfoDto());
}

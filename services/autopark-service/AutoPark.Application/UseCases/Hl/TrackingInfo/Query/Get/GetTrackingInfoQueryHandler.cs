using MediatR;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoQueryHandler :
    IRequestHandler<GetTrackingInfoQuery, TrackingInfoDto>
{
    public Task<TrackingInfoDto> Handle(
        GetTrackingInfoQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new TrackingInfoDto());
}

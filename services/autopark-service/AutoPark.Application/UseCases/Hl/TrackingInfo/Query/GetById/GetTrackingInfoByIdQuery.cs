using MediatR;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoByIdQuery :
    IRequest<TrackingInfoDto>
{
    public long Id { get; set; }
}

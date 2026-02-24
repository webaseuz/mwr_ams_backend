using MediatR;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoBriefResultQuery :
    IStreamRequest<List<List<TrackingInfoBriefDto>>>
{
    public long? PersonId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}


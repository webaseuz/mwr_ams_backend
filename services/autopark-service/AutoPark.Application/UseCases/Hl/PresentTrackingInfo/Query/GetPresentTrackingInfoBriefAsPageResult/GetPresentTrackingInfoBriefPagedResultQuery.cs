using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoBriefPagedResultQuery :
    IRequest<IEnumerable<PresentTrackingInfoBriefDto>>
{ }

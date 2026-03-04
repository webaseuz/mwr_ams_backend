using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPresentTrackingInfoQueryHandler : IRequestHandler<PresentTrackingInfoGetListQuery, IEnumerable<PresentTrackingInfoBriefDto>>
{
    public Task<IEnumerable<PresentTrackingInfoBriefDto>> Handle(
        PresentTrackingInfoGetListQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(Enumerable.Empty<PresentTrackingInfoBriefDto>());
}

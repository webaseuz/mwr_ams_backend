using MediatR;

namespace Erp.Service.Adm.Models;

public class PresentTrackingInfoGetListQuery : IRequest<IEnumerable<PresentTrackingInfoBriefDto>>
{
}

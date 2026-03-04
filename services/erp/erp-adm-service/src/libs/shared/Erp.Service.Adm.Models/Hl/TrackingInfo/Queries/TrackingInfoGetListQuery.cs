using MediatR;

namespace Erp.Service.Adm.Models;

public class TrackingInfoGetListQuery : IStreamRequest<List<List<TrackingInfoBriefDto>>>
{
    public long? PersonId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

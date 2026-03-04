using MediatR;

namespace Erp.Service.Adm.Models;

public class TrackingInfoGetDriverAndTransportInfoQuery : IRequest<DriverAndTransportInfoDto>
{
    public long PersonId { get; set; }
}

using MediatR;

namespace Erp.Service.Adm.Models;

public class TrackingInfoGetByIdQuery : IRequest<TrackingInfoDto>
{
    public long Id { get; set; }
}

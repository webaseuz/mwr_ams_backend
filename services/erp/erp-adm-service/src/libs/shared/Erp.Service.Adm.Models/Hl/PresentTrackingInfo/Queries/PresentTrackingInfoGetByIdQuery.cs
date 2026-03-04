using MediatR;

namespace Erp.Service.Adm.Models;

public class PresentTrackingInfoGetByIdQuery : IRequest<PresentTrackingInfoDto>
{
    public long Id { get; set; }
}

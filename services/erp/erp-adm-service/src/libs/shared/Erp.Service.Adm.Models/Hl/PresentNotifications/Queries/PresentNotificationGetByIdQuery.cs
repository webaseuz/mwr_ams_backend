using MediatR;

namespace Erp.Service.Adm.Models;

public class PresentNotificationGetByIdQuery : IRequest<PresentNotificationDto>
{
    public long Id { get; set; }
}

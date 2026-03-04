using MediatR;

namespace Erp.Service.Adm.Models;

public class NotificationGetByIdQuery : IRequest<NotificationDto>
{
    public long Id { get; set; }
}

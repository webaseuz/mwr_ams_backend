using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateNotificationCommandHandler(
    INotificationService notificationService) : IRequestHandler<NotificationCreateCommand, bool>
{
    public async Task<bool> Handle(NotificationCreateCommand request, CancellationToken cancellationToken)
    {
        return await notificationService.AddDriverPenaltyNotificationAsync(cancellationToken);
    }
}

using Erp.Core.Service.Domain;

namespace Erp.Service.Adm.Application.UseCases;

public interface INotificationService
{
    string GenerateMessageFromTemplate<TEntity>(NotificationTemplate templete, TEntity dto)
        where TEntity : class;

    Task<bool> AddNotificationAsync(Notification notification, CancellationToken cancellationToken);

    Task<bool> AddDriverPenaltyNotificationAsync(CancellationToken cancellationToken);
}

using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.NotificationServices;

public interface INotificationService
{
	string GenerateMessageFromTemplate<TEntity>(NotificationTemplate templete, TEntity dto)
		where TEntity : class;

	Task<bool> AddNotificationAsync(Notification notification, CancellationToken cancellationToken);
}

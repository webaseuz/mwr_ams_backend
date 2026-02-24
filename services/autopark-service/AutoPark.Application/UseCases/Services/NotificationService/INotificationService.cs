using AutoPark.Domain;
using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.NotificationServices;

public interface INotificationService
{
    string GenerateMessageFromTemplate<TEntity>(NotificationTemplate templete, TEntity dto)
        where TEntity : class;

    Task<bool> AddNotificationAsync(Notification notification, CancellationToken cancellationToken);

    Task<SuccessResult<bool>> AddDriverPenaltyNotificationAsync(CancellationToken cancellationToken);
}

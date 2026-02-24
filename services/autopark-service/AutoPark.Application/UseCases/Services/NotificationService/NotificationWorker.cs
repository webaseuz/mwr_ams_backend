using Microsoft.Extensions.Logging;
using Quartz;

namespace AutoPark.Application.UseCases.NotificationServices;

public class NotificationWorker : IJob
{
    private readonly INotificationService _notificationService;
    private readonly ILogger<NotificationWorker> _logger;
    public NotificationWorker(
        INotificationService notificationService,
        ILogger<NotificationWorker> logger)
    {
        _logger = logger;
        _notificationService = notificationService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            _logger.LogInformation($"Start Job NotificationWorker Service ({DateTime.Now.ToString()})");
            await Task.Run(() => _notificationService.AddDriverPenaltyNotificationAsync(new CancellationToken()));
        }
        catch (Exception)
        {
            throw;
        }
    }
}

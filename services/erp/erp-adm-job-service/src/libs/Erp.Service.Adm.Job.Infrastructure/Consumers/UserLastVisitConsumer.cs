using Erp.Core.Service.Application;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.Abstraction;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.Job.Infrastructure.Consumers;

public class UserLastVisitConsumerConfig : IWbConsumerConfig<UserLastVisitMessage>
{
    public string Name => "MadErpUserLastVisit";
    public WbRabbitQueue Queue => AdmQueues.UserLastVisit;
    public ushort PrefetchCount { get; set; } = 1;
    public int WorkerCount { get; set; } = 1;
    public bool RequeueOnFailed { get; set; } = true;
}

public class UserLastVisitConsumer(IApplicationDbContext dbContext, ILogger<UserLastVisitConsumer> logger) : IWbConsumer<UserLastVisitMessage>
{
    public async Task ConsumeAsync(UserLastVisitMessage message, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == message.UserId, cancellationToken);
        if (user == null)
        {
            logger.LogError($"Error consuming user last visit message: User not found with Id = {message.UserId}");
        }

        user.LastVisitAt = message.LastVisitAt;
        user.LastVisitAppId = message.LastVisitAppId;

        await dbContext.SaveChangesAsync(cancellationToken);

    }
}

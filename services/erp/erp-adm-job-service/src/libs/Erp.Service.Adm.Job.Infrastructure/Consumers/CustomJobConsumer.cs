using Erp.Core.Service.Application;
using Erp.Service.Adm.Job.Application;
using Erp.Service.Adm.Job.Application.Services.JobRunners;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.Abstraction;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.Job.Infrastructure.Consumers;

public class CustomJobConsumerConfig : IWbConsumerConfig<CustomJobMessage>
{
    public string Name => "MadErpCustomJob";
    public WbRabbitQueue Queue => AdmQueues.CustomJob;
    public ushort PrefetchCount { get; set; } = 1;
    public int WorkerCount { get; set; } = 1;
    public bool RequeueOnFailed { get; set; } = true;
}

public class CustomJobConsumer : IWbConsumer<CustomJobMessage>
{   
    private readonly ICustomJobRunnerFactory _customJobRunnerFactory;
    private readonly IMainAuthService _authService;
    private readonly ILogger<CustomJobConsumer> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IApplicationDbContext _dbContext;

    public CustomJobConsumer(ICustomJobRunnerFactory customJobRunnerFactory,
        IMainAuthService authService,
        ILogger<CustomJobConsumer> logger,
        IServiceProvider serviceProvider,
        IApplicationDbContext dbContext)
    {
        _customJobRunnerFactory = customJobRunnerFactory;
        _authService = authService;
        _logger = logger;
        _serviceProvider = serviceProvider;
        _dbContext = dbContext;
    }

    public async Task ConsumeAsync(CustomJobMessage message, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _dbContext.CustomJobs.FirstOrDefault(a => a.Id == message.DocId);
            
            if (entity?.CreatedBy != null)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == entity.CreatedBy.Value);
                if (user != null)
                {
                    _authService.ResetUserName(user.UserName);
                }
            }
            
            ICustomJobRunner jobRunner = _customJobRunnerFactory.GetJobRunner(entity.JobTypeId);
            await jobRunner.Run(entity.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error consuming CustomJobMessage for DocId: {DocId}", message.DocId);
        }
    }
}

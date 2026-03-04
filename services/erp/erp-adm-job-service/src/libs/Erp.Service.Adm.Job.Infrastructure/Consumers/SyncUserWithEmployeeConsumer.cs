using Erp.Core.Service.Application;
using Erp.Service.Adm.Job.Application;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Erp.Service.Adm.Sdk;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.Abstraction;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.Job.Infrastructure.Consumers;

public class SyncUserWithEmployeeConsumerConfig : IWbConsumerConfig<SyncUserWithEmployeeMessage>
{
    public string Name => "MadErpSyncUserWithEmployee";
    public WbRabbitQueue Queue => AdmQueues.SyncUserWithEmployee;
    public ushort PrefetchCount { get; set; } = 1;
    public int WorkerCount { get; set; } = 1;
    public bool RequeueOnFailed { get; set; } = true;
}

public class SyncUserWithEmployeeConsumer : IWbConsumer<SyncUserWithEmployeeMessage>
{
    private readonly IMainAuthService _authService;
    private readonly ILogger<SyncUserWithEmployeeConsumer> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IApplicationDbContext _dbContext;
    private readonly IUserApi _userApi;

    public SyncUserWithEmployeeConsumer(
        IMainAuthService authService,
        ILogger<SyncUserWithEmployeeConsumer> logger,
        IServiceProvider serviceProvider,
        IApplicationDbContext dbContext,
        IUserApi userApi)
    {
        _authService = authService;
        _logger = logger;
        _serviceProvider = serviceProvider;
        _dbContext = dbContext;
        _userApi = userApi;
    }

    public async Task ConsumeAsync(SyncUserWithEmployeeMessage message, CancellationToken cancellationToken)
    {
        await _userApi.SyncUserWithEmployeeAsync(new Models.SyncUserWithEmployeeCommand
        {
            UserEmployees = message.UserEmployees.Select(a => new Models.UserEmployeeDto
            {
                PersonId = a.PersonId,
                PhoneNumber = a.PhoneNumber,
                Assignments = a.Assignments.Select(b => new Models.UserEmployeeAssignmentDto
                {
                    InstitutionTypeId = b.InstitutionTypeId,
                    OrganizationId = b.OrganizationId,
                    OrganizationTypeId = b.OrganizationTypeId,
                    PositionId = b.PositionId
                }).ToList()
            }).ToList()
        });
    }
}


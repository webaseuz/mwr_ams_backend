using Erp.Service.Adm.Job.Infrastructure.Consumers;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Extensions;
using Erp.Service.Audit.RabbitMQ.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.Job.Infrastructure;

public static class RabbitMQExtensions
{
    public static void ConfigureRabbitMQ(this IServiceCollection services, IConfiguration config)
    {
        //Publisher
        services.AddRabbitMQPublisherClient(options =>
        {
            config.GetSection("RabbitMQ").Bind(options);
        })
        .AddAdmPublishers()
        .AddAuditPublishers();

        //Consumer
        services.AddSingleton<IWbConsumerErrorHandler, WbConsumerErrorHandler>();
        services.AddRabbitMQConsumerClient(options =>
        {
            config.GetSection("RabbitMQ").Bind(options);
        })
        .AddConsumer<CustomJobMessage, CustomJobConsumerConfig, CustomJobConsumer>(options =>
        {
            config.GetSection("RabbitMQ:Consumers:CustomJob").Bind(options);
        })
        .AddConsumer<SyncUserWithEmployeeMessage, SyncUserWithEmployeeConsumerConfig, SyncUserWithEmployeeConsumer>(options =>
        {
            config.GetSection("RabbitMQ:Consumers:SyncUserWithEmployee").Bind(options);
        })
        .AddConsumer<UserLastVisitMessage, UserLastVisitConsumerConfig, UserLastVisitConsumer>(options =>
        {
            config.GetSection("RabbitMQ:Consumers:UserLastVisit").Bind(options);
        });
    }
}

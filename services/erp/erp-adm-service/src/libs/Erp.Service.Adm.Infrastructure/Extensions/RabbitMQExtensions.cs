using Erp.Service.Adm.RabbitMQ.Extensions;
using Erp.Service.Audit.RabbitMQ.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.Infrastructure;

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
    }
}

using Erp.Service.Adm.MessageBroker.Publishers;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Publishers;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdmPublishers(this IServiceCollection services)
        {
            services.AddPublisher<CustomJobMessage, CustomJobPublisher>();
            services.AddPublisher<SyncUserWithEmployeeMessage, SyncUserWithEmployeePublisher>();
            services.AddPublisher<UserLastVisitMessage, UserLastVisitPublisher>();

            services.AddScoped<ICustomJobPublisher, CustomJobPublisher>();
            services.AddScoped<ISyncUserWithEmployeePublisher, SyncUserWithEmployeePublisher>();
            services.AddScoped<IUserLastVisitPublisher, UserLastVisitPublisher>();

            return services;
        }
    }
}

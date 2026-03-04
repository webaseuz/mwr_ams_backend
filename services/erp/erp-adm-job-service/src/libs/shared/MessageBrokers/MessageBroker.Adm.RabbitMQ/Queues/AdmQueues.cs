using RabbitMQ.Client;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Queues;

public static partial class AdmQueues
{
    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-adm-job-service
    /// </summary>
    public static WbRabbitQueue CustomJob = new WbRabbitQueue
    {
        Name = "mad-erp-custom-job-queue",
        Exchange = "mad-erp-custom-job-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-custom-job-route",
        Producer = "*",
        Consumer = "mad-erp-custom-job-service"
    };

    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-sync-user-with-employee-service
    /// </summary>
    public static WbRabbitQueue SyncUserWithEmployee = new WbRabbitQueue
    {
        Name = "mad-erp-sync-user-with-employee-queue",
        Exchange = "mad-erp-sync-user-with-employee-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-sync-user-with-employee-route",
        Producer = "*",
        Consumer = "mad-erp-sync-user-with-employee-service"
    };

    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-user-last-visit-service
    /// </summary>
    public static WbRabbitQueue UserLastVisit = new WbRabbitQueue
    {
        Name = "mad-erp-user-last-visit-queue",
        Exchange = "mad-erp-user-last-visit-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-user-last-visit-route",
        Producer = "*",
        Consumer = "mad-erp-user-last-visit-service"
    };
}

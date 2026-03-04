using RabbitMQ.Client;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Queues;

public static partial class AuditQueues
{
    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-audit-service
    /// </summary>
    public static WbRabbitQueue DocumentHistory = new WbRabbitQueue
    {
        Name = "mad-erp-doc-history-queue",
        Exchange = "mad-erp-doc-history-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-doc-history-route",
        Producer = "*",
        Consumer = "mad-erp-doc-history-service"
    };

    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-audit-service  
    /// </summary>
    public static WbRabbitQueue RowHistory = new WbRabbitQueue
    {
        Name = "mad-erp-row-history-queue",
        Exchange = "mad-erp-row-history-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-row-history-route",
        Producer = "*",
        Consumer = "mad-erp-row-history-service"
    };

    /// <summary>
    /// Producer -> any services
    /// Consumer -> mad-erp-audit-service
    /// </summary>
    public static WbRabbitQueue HlHistory = new WbRabbitQueue
    {
        Name = "mad-erp-hl-history-queue",
        Exchange = "mad-erp-hl-history-exchange",
        ExchangeType = ExchangeType.Direct,
        RoutingKey = "mad-erp-hl-history-route",
        Producer = "*",
        Consumer = "mad-erp-hl-history-service"
    };
}

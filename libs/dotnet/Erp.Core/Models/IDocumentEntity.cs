namespace Erp.Core.Models;

public interface IDocumentEntity<TId> : IBaseEntity<TId> where TId : struct
{
    int StatusId { get; set; }
    int OrganizationId { get; set; }
    int TableId { get; set; }
}

public interface IDocumentEntity : IDocumentEntity<long> { }

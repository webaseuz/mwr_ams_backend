namespace Bms.Core.Domain.Domains;

public interface IDocumentEntity
{
    void AddHistory(Guid Id, string userInfo);
}
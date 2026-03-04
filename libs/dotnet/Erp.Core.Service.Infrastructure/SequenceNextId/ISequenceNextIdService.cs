namespace Erp.Core.Service.Infrastructure;

public interface ISequenceNextIdService
{
    Task<long> GetSequenceNextId(string sequenceName, CancellationToken cancellationToken);
}

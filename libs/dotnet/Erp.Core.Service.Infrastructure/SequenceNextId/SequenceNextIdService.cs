using Erp.Core.Service.Application;
using Microsoft.EntityFrameworkCore;

namespace Erp.Core.Service.Infrastructure;

public class SequenceNextIdService : ISequenceNextIdService
{
    private readonly IApplicationDbContext _context;
    public SequenceNextIdService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> GetSequenceNextId(string sequenceName, CancellationToken cancellationToken)
    {
        var sql = $"SELECT nextval('{sequenceName}') as Value";
        var result = await _context.Database
            .SqlQueryRaw<SequenceResult>(sql)
            .FirstOrDefaultAsync(cancellationToken);

        return result?.value ?? 0;
    }
}
public class SequenceResult
{
    public long value { get; set; }
}


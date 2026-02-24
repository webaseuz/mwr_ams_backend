using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;

public interface ISpareTurnoverService
{
    Task InsertSpareTurnoverRow(SpareTurnoverParameter parametrs,
                                CancellationToken cancellationToken);
    Task RemoveSpareTurnoverRow(RemoveSpareTurnoverRowDto dto,
                                             CancellationToken cancellationToken);
}

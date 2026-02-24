using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class CancelNotificationTemplateSettingCommandHandler :
    IRequestHandler<CancelNotificationTemplateSettingCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    public CancelNotificationTemplateSettingCommandHandler(
        IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<IHaveId<long>> Handle(
        CancelNotificationTemplateSettingCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.NotificationTemplateSettings
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Cancel();

            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

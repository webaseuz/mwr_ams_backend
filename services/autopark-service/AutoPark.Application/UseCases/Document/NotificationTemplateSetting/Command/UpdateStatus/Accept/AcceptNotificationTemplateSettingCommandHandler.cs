using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class AcceptNotificationTemplateSettingCommandHandler :
    IRequestHandler<AcceptNotificationTemplateSettingCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    public AcceptNotificationTemplateSettingCommandHandler(
        IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<IHaveId<long>> Handle(
        AcceptNotificationTemplateSettingCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.NotificationTemplateSettings
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            var hasAcceptedDocument = await _context.NotificationTemplateSettings
                                      .AnyAsync(x => x.BranchId == document.BranchId
                                                && x.StatusId == StatusIdConst.ACCEPTED
                                                && x.NotificationTemplateId == document.NotificationTemplateId);
            if (hasAcceptedDocument)
                throw ClientLogicalExceptionHelper.AcceptedDocumentAlreadyExists(nameof(document.NotificationTemplete));

            document.Accept();

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

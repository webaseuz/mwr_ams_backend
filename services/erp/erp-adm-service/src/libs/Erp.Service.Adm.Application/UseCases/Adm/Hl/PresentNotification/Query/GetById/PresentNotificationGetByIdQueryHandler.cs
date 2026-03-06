using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class PresentNotificationGetByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<PresentNotificationGetByIdQuery, PresentNotificationDto>
{
    public async Task<PresentNotificationDto> Handle(PresentNotificationGetByIdQuery request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await context.PresentNotifications
                .Include(x => x.NotificationTemplate)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DOCUMENT_NOT_FOUND",
                        ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                    });

            var dto = mapper.Map<PresentNotificationDto>(entity);

            var owner = await context.Notifications
                .FirstOrDefaultAsync(x => x.Id == entity.OwnerId, cancellationToken);

            if (owner is not null)
            {
                owner.IsRead = true;
                owner.ReadAt = DateTime.Now;
            }

            await context.PresentNotifications
                .Where(x => x.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return dto;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}

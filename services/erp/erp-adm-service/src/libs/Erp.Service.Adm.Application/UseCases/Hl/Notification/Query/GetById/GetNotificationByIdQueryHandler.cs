using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetNotificationByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<NotificationGetByIdQuery, NotificationDto>
{
    public async Task<NotificationDto> Handle(NotificationGetByIdQuery request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await context.Notifications
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "NOTIFICATION_NOT_FOUND",
                        ErrorMessage = localizationBuilder.For("NOTIFICATION_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                    });

            entity.IsRead = true;
            entity.ReadAt = DateTime.Now;
            await context.SaveChangesAsync(cancellationToken);

            var dto = mapper.Map<NotificationDto>(entity);

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
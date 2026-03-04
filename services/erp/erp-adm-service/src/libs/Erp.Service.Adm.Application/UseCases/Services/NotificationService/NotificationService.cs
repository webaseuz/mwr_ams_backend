using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationService : INotificationService
{
    private readonly IApplicationDbContext _context;
    private readonly ILocalizationBuilder _localizationBuilder;

    public NotificationService(IApplicationDbContext context, ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<bool> AddNotificationAsync(Notification notification, CancellationToken cancellationToken)
    {
        await _context.Notifications.AddAsync(notification, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var presentNtEntity = new PresentNotification
        {
            OwnerId = notification.Id,
            Message = notification.Message,
            Subject = notification.Subject,
            NotificationTemplateId = notification.NotificationTemplateId,
            SendAt = DateTime.Now,
            UserId = notification.UserId,
        };

        await _context.PresentNotifications.AddAsync(presentNtEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return notification.Id != 0 && presentNtEntity.Id != 0;
    }

    public async Task<bool> AddDriverPenaltyNotificationAsync(CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var template = await _context.NotificationTemplates
                .FirstOrDefaultAsync(x => x.Key == "DRIVER_PENALTY", cancellationToken);

            if (template == null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "NOTIFICATION_TEMPLATE_NOT_FOUND",
                        ErrorMessage = _localizationBuilder.For("NOTIFICATION_TEMPLATE_NOT_FOUND").WithData(new { Key = "DRIVER_PENALTY" }).ToString()
                    });

            var notificationSubjects = await _context.Notifications
                .Where(x => x.NotificationTemplateId == template.Id)
                .AsNoTracking()
                .Select(x => x.Subject)
                .ToListAsync(cancellationToken);

            var processedPenaltyIds = notificationSubjects
                .Where(s => long.TryParse(s, out _))
                .Select(long.Parse)
                .ToList();

            var driversPenalties = await _context.DriverPenalties
                .Where(x => x.DiscountDate >= DateTime.Now.AddDays(3) && !processedPenaltyIds.Contains(x.Id))
                .Include(x => x.Person)
                .Include(x => x.Transport)
                .ToListAsync(cancellationToken);

            if (!driversPenalties.Any())
                return false;

            var userTemplate = await _context.NotificationTemplateSettings
                .Where(x => x.NotificationTemplateId == template.Id && x.StatusId == StatusIdConst.ACCEPTED)
                .Include(x => x.Users)
                .Include(x => x.Roles)
                .Include(x => x.RestrictedUsers)
                .FirstOrDefaultAsync(cancellationToken);

            var query = _context.Users
                .Include(x => x.UserRoles)
                .Where(x => x.StateId == WbStateIdConst.ACTIVE);

            if (userTemplate?.Roles.Count > 0)
            {
                var roleIds = userTemplate.Roles.Select(x => x.RoleId).ToList();
                query = query.Where(x => x.UserRoles.Any(ur => roleIds.Contains(ur.RoleId)));
            }
            else if (userTemplate?.Users.Count > 0)
            {
                var ids = userTemplate.Users.Select(x => x.UserId).ToList();
                query = query.Where(x => ids.Contains(x.Id));
            }

            if (userTemplate?.RestrictedUsers.Count > 0)
            {
                var restrictedUserIds = userTemplate.RestrictedUsers.Select(x => x.UserId).ToList();
                query = query.Where(x => !restrictedUserIds.Contains(x.Id));
            }

            var userIds = await query.Select(x => x.Id).ToListAsync(cancellationToken);

            foreach (var penalty in driversPenalties)
            {
                var res = new PenaltyTemplateDto
                {
                    DriverName = penalty.Person.FullName,
                    CarNumber = penalty.Transport.StateNumber,
                    DiscountDeadline = penalty.Discount50Date?.ToString("yyyy-MM-dd HH:mm") ?? "",
                    FullPaymentDeadline = penalty.DiscountDate?.ToString("yyyy-MM-dd HH:mm") ?? "",
                    FineAmount = penalty.Amount,
                    FineDate = penalty.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                };

                var message = GenerateMessageFromTemplate(template, res);
                foreach (var id in userIds)
                {
                    var ntEntity = new Notification
                    {
                        Subject = penalty.Id.ToString(),
                        Message = message,
                        UserId = id,
                        SentAt = DateTime.Now,
                        StateId = WbStateIdConst.ACTIVE,
                        NotificationTemplateId = template.Id,
                    };
                    await AddNotificationAsync(ntEntity, cancellationToken);
                }
            }

            await transaction.CommitAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public string GenerateMessageFromTemplate<TEntity>(NotificationTemplate templete, TEntity dto)
        where TEntity : class
    {
        if (typeof(TEntity) == typeof(StatusTemplateDto))
            return MessageRender.DocStatusTemplate<TEntity>(templete.Message, dto);
        else if (typeof(TEntity) == typeof(PenaltyTemplateDto))
            return MessageRender.DocStatusTemplate(templete.Message, dto);
        else
            return null;
    }
}

public static class MessageRender
{
    public static string DocStatusTemplate<TEntity>(string template, TEntity dto)
        where TEntity : class
    {
        if (string.IsNullOrWhiteSpace(template) || dto == null)
            return template;

        var result = new StringBuilder(template);
        var properties = dto.GetType().GetProperties();
        foreach (var prop in properties)
        {
            var value = prop.GetValue(dto)?.ToString() ?? string.Empty;
            string placeholder = $"{{{prop.Name}}}";
            result = result.Replace(placeholder, value);
        }

        return result.ToString();
    }
}

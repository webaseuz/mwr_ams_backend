using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AutoPark.Application.UseCases.NotificationServices;

public class NotificationService : INotificationService
{
    private readonly IWriteEfCoreContext _context;
    public NotificationService(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<bool> AddNotificationAsync(Notification notification, CancellationToken cancellationToken)
    {
        var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction();

        bool canCommit = _context.Database.CurrentTransaction == null;

        try
        {
            var resultNT = await _context.CreateAndSaveAsync<long, Notification>(notification, cancellationToken);

            var presentNtEntity = new PresentNotification()
            {
                OwnerId = resultNT,
                Message = notification.Message,
                Subject = notification.Subject,
                NotificationTemplateId = notification.NotificationTemplateId,
                SendAt = DateTime.Now,
                UserId = notification.UserId,
            };
            var result = await _context.CreateAndSaveAsync<long, PresentNotification>(presentNtEntity, cancellationToken);
            return resultNT != 0 && result != 0;
        }
        catch (Exception)
        {
            if (canCommit)
                await transaction.RollbackAsync(cancellationToken);

            throw;
        }


    }
    public async Task<SuccessResult<bool>> AddDriverPenaltyNotificationAsync(CancellationToken cancellationToken)
    {
        var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var template = await _context.NotificationTemplates
                        .FirstOrDefaultAsync(x => x.Key == NotificationTemplateConst.DRIVER_PENALTY, cancellationToken);

            if (template == null)
                throw ClientLogicalExceptionHelper.NotificationTemplateNotFound(NotificationTemplateConst.DRIVER_PENALTY);

            var notifications = await _context.Notifications
                                .Where(x => x.NotificationTemplateId == template.Id).AsNoTracking()
                                .Select(x => long.Parse(x.Subject))
                                .ToListAsync();

            var driversPenalties = await _context.DriverPenalties
                                .Where(x => x.DiscountDate >= DateTime.Now.AddDays(3) && !notifications.Contains(x.Id))
                                .Include(x => x.Person)
                                .Include(x => x.Transport)
                                .ToListAsync();

            if (driversPenalties == null)
                return SuccessResult.Create(false);

            var userTemplate = await _context.NotificationTemplateSettings
                                .Where(x => x.NotificationTemplateId == template.Id
                                            && x.StatusId == StatusIdConst.ACCEPTED)
                               .Include(x => x.Users)
                               .Include(x => x.Roles)
                               .Include(x => x.RestrictedUsers)
                               .FirstOrDefaultAsync(cancellationToken);

            var query = _context.Users
                        .Include(x => x.UserRoles)
                        .Where(x => x.StateId == StateIdConst.ACTIVE);

            if (userTemplate.Roles.Count > 0)
            {
                var roleIds = userTemplate.Roles.Select(x => x.RoleId).ToList();
                query = query.Where(x => x.UserRoles.Any(ur => roleIds.Contains(ur.RoleId)));
            }
            else if (userTemplate.Users.Count > 0)
            {
                var Ids = userTemplate.Users.Select(x => x.UserId).ToList();
                query = query.Where(x => Ids.Contains(x.Id));
            }
            if (userTemplate.RestrictedUsers.Count > 0)
            {
                var restrictedUserIds = userTemplate.RestrictedUsers.Select(x => x.UserId).ToList();
                query = query.Where(x => !restrictedUserIds.Contains(x.Id));
            }

            var userIds = await query.Select(x => x.Id).ToListAsync();
            foreach (var penalty in driversPenalties)
            {
                var res = new PenaltyTemplateDto()
                {
                    DriverName = penalty.Person.FullName,
                    CarNumber = penalty.Transport.StateNumber,
                    DiscountDeadline = penalty.Discount50Date?.ToString("yyyy-MM-dd HH:mm") ?? "",
                    FullPaymentDeadline = penalty.DiscountDate?.ToString("yyyy-MM-dd HH:mm") ?? "",
                    FineAmount = penalty.Amount,
                    FineDate = penalty.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                };

                var message = GenerateMessageFromTemplate<PenaltyTemplateDto>(template, res);
                foreach (var Id in userIds)
                {
                    var ntEntity = new Notification()
                    {
                        Subject = penalty.Id.ToString(),
                        Message = message,
                        UserId = Id,
                        SentAt = DateTime.Now,
                        NotificationTemplateId = template.Id,
                    };
                    var succesResult = await AddNotificationAsync(ntEntity, cancellationToken);
                }
            }
            await transaction.CommitAsync(cancellationToken);
            return SuccessResult.Create(true);
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

/*✅ Hujjat tasdiqlandi qilindi!

Raqami: {DocNumber}  
Hujjat turi: { DocumentType}
Tasdiqlovchi foydalanuvchi: { AcceptedBy}
Tasdiqlangan vaqt: { AcceptedAt}
Bo‘lim: { BranchName}

Hujjat holati: { Status}

Rahmat!
*/


/*✅ Hujjat rad qilindi!

Raqami: {DocNumber}  
Hujjat turi: { DocumentType}
Tasdiqlovchi foydalanuvchi: { CanceledBy}
Tasdiqlangan vaqt: { CanceledAt}
Bo‘lim: { BranchName}

Hujjat holati: { Status}

Rahmat!
*/
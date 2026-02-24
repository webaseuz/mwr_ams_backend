using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ServiceDesk.Application.UseCases.NotificationServices;

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

            /*var presentNtEntity = new PresentNotification()
            {
                OwnerId = resultNT,
                Message = notification.Message,
                Subject = notification.Subject,
                NotificationTemplateId = notification.NotificationTemplateId,
                SendAt = DateTime.Now,
                UserId = notification.UserId,
            };
            var result = await _context.CreateAndSaveAsync<long, PresentNotification>(presentNtEntity, cancellationToken);*/
            return resultNT != 0; //&& result != 0;
        }
		catch (Exception)
		{
            if (canCommit)
                await transaction.RollbackAsync(cancellationToken);

            throw;
        }
        
	}
    
    public string GenerateMessageFromTemplate<TEntity>(NotificationTemplate templete, TEntity dto)
		where TEntity : class
	{
		if (typeof(TEntity) == typeof(StatusTemplateDto))
			return MessageRender.DocStatusTemplate<TEntity>(templete.Message, dto);
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
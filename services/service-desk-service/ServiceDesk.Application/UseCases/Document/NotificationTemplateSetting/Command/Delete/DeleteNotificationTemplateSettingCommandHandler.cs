using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class DeleteNotificationTemplateSettingCommandHandler :
	IRequestHandler<DeleteNotificationTemplateSettingCommand, SuccessResult<bool>>
{
	public readonly IWriteEfCoreContext _context;
	public DeleteNotificationTemplateSettingCommandHandler(
		IWriteEfCoreContext context)
	{
		_context = context;
	}

	public async Task<SuccessResult<bool>> Handle(
		DeleteNotificationTemplateSettingCommand request,
		CancellationToken cancellationToken)
	{
		using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
		try
		{
			var entity = await _context.NotificationTemplateSettings
		   .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

			if (entity == null)
				throw ClientLogicalExceptionHelper.NotFound(request.Id);

			entity.Delete();
			await _context.SaveChangesAsync(cancellationToken);

			await transaction.CommitAsync(cancellationToken);
			return SuccessResult.Create(true);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync(cancellationToken);
			throw;
		}
	}
}

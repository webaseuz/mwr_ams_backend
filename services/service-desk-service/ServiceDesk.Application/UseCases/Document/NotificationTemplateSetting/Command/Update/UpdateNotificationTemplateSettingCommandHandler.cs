using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingCommandHandler :
	IRequestHandler<UpdateNotificationTemplateSettingCommand, IHaveId<long>>
{
	private readonly IWriteEfCoreContext _context;
	private readonly IMapProvider _mapper;

	public UpdateNotificationTemplateSettingCommandHandler(
		IWriteEfCoreContext context,
		IMapProvider mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public async Task<IHaveId<long>> Handle(
		UpdateNotificationTemplateSettingCommand request,
		CancellationToken cancellationToken)
	{
		var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

		try
		{
			var entity = await _context.NotificationTemplateSettings
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity == null)
				throw ClientLogicalExceptionHelper.NotFound(request.Id);

			request.UpdateEntity(entity, _mapper);
			request.Users.ApplyChangesTo<long, UpdateNotificationTemplateSettingUserCommand, NotificationTemplateSettingUser>(entity.Users, _mapper);
			request.Roles.ApplyChangesTo<long, UpdateNotificationTemplateSettingRoleCommand, NotificationTemplateSettingRole>(entity.Roles, _mapper);
			request.RestrictedUsers.ApplyChangesTo<long, UpdateNotificationTemplateSettingRestrictedUserCommand, NotificationTemplateSettingRestrictedUser>(entity.RestrictedUsers, _mapper);

			entity.Update();
			await _context.SaveChangesAsync(cancellationToken);

			await transaction.CommitAsync();

			return HaveId.Create(request.Id);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync(cancellationToken);
			throw;
		}
	}
}

using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingCommandHandler :
	IRequestHandler<CreateNotificationTemplateSettingCommand, IHaveId<long>>
{
	private readonly IAsyncAppAuthService _authService;
	private readonly INumberService _numberService;
    private readonly IWriteEfCoreContext _context;
	private readonly IMapProvider _mapper;

	public CreateNotificationTemplateSettingCommandHandler(
		IAsyncAppAuthService authService,
		INumberService numberService,
		IWriteEfCoreContext context, 
		IMapProvider mapper)
	{
		_numberService = numberService;
		_authService = authService;
		_context = context;
		_mapper = mapper;
	}
	public async Task<IHaveId<long>> Handle(
		CreateNotificationTemplateSettingCommand request,
		CancellationToken cancellationToken)
	{
		var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

		try
		{
			var entity = request.CreateEntity<CreateNotificationTemplateSettingCommand, NotificationTemplateSetting>(_mapper);
			entity.DocDate = DateTime.UtcNow.Date;

            var docNumberResult = _numberService.GetNext(NumberTamplateDocumentConst.NOTIFICATION_TEMPLATE_SETTING);
            entity.DocNumber = docNumberResult.docNumber;
			
			var userInfo = await _authService.GetUserAsync();

			if (!userInfo.Permissions.Contains(nameof(PermissionCode.NotificationTemplateSettingCreateForAllBranch)))
				entity.BranchId = userInfo.BranchId;
			
			entity.Create();

			var haveSameIds = request.Users.Select(x => x.UserId).Intersect(request.RestrictedUsers.Select(x => x.UserId)).Any();

			if (request.Users.Any() && request.RestrictedUsers.Any() && haveSameIds)
				throw ClientLogicalExceptionHelper.Wrap($"{nameof(request.Users)} и {nameof(request.RestrictedUsers)} — это одни и те же пользователи.", ErrorCode.CLIENT_WRONG_STATUS);
			
			request.Users.AddTo(entity.Users, _mapper);
			
			request.Roles.AddTo(entity.Roles, _mapper);
			
			request.RestrictedUsers.AddTo(entity.RestrictedUsers, _mapper);

			var result = await _context.CreateAndSaveAsync<long, NotificationTemplateSetting>(entity, cancellationToken);

			await transaction.CommitAsync();

			return HaveId.Create(result);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync(cancellationToken);
			throw;
		}
	}
}

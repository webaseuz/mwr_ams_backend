using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.NotificationServices;

namespace ServiceDesk.Application.UseCases.Notifications;

/*public class CreateNotificationCommandHandler :
    IRequestHandler<CreateNotificationCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly INotificationService _notificationService;
    public CreateNotificationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        INotificationService notificationService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _notificationService = notificationService;
    }

    public async Task<SuccessResult<bool>> Handle(
        CreateNotificationCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}*/
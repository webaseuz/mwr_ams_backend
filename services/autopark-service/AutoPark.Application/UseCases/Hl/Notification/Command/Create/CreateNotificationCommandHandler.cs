using AutoPark.Application.Security;
using AutoPark.Application.UseCases.NotificationServices;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class CreateNotificationCommandHandler :
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
        var result = await _notificationService.AddDriverPenaltyNotificationAsync(cancellationToken);
        return result;
    }
}

using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.PresentNotifications;

public class GetPresentNotificationByIdQueryHandler :
    IRequestHandler<GetPresentNotificationByIdQuery, PresentNotificationDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly IWriteEfCoreContext _wContext;
    public GetPresentNotificationByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        IWriteEfCoreContext wContext)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _wContext = wContext;
    }

    public async Task<PresentNotificationDto> Handle(
        GetPresentNotificationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.PresentNotifications
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<PresentNotification, PresentNotificationDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var transaction = await _wContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var owner = await _wContext.Notifications
                        .FirstOrDefaultAsync(x => x.Id == dto.OwnerId, cancellationToken);

            owner.IsRead = true;
            owner.ReadAt = DateTime.Now;

            await _wContext.SaveChangesAsync(cancellationToken);

            await _wContext.PresentNotifications.Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

            await _wContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

        return dto;
    }

}
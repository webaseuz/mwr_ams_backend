using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingByIdQueryHandler :
    IRequestHandler<GetNotificationTemplateSettingByIdQuery, NotificationTemplateSettingDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetNotificationTemplateSettingByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<NotificationTemplateSettingDto> Handle(
        GetNotificationTemplateSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.NotificationTemplateSettings
            .Include(x => x.Users)
            .Include(x => x.Roles)
            .Include(x => x.RestrictedUsers)
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<NotificationTemplateSetting, NotificationTemplateSettingDto>(query)
            .FirstOrDefaultAsync(cancellationToken);


        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);


        dto.CanCreateForAllBranch = await _authService.HasPermissionAsync(nameof(PermissionCode.NotificationTemplateSettingCreateForAllBranch));


        return dto;
    }
}

using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class PresentNotificationGetByUserQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper,
    IMainAuthService authService) : IRequestHandler<PresentNotificationGetByUserQuery, WbPagedResult<PresentNotificationBriefDto>>
{
    public async Task<WbPagedResult<PresentNotificationBriefDto>> Handle(PresentNotificationGetByUserQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        var query = context.PresentNotifications
            .MapTo<PresentNotificationBriefDto>(mapper, cultureHelper)
            .Where(x => x.UserId == userInfo.Id);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSearch())
            query = query.Where(x => x.Subject.ToLower().Contains(request.Search!.ToLower()));

        return await query.AsPagedResultAsync(request);
    }
}

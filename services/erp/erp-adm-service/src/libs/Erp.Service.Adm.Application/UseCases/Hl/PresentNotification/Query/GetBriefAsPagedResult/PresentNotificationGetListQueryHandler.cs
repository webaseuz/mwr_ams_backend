using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class PresentNotificationGetListQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper) : IRequestHandler<PresentNotificationGetListQuery, WbPagedResult<PresentNotificationBriefDto>>
{
    public async Task<WbPagedResult<PresentNotificationBriefDto>> Handle(PresentNotificationGetListQuery request, CancellationToken cancellationToken)
    {
        var query = context.PresentNotifications
            .MapTo<PresentNotificationBriefDto>(mapper, cultureHelper);

        if (request.UserId.HasValue)
            query = query.Where(x => x.UserId == request.UserId);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (request.HasSearch())
            query = query.Where(x => x.Subject.ToLower().Contains(request.Search!.ToLower()));

        return await query.AsPagedResultAsync(request);
    }
}

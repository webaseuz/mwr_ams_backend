using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPresentTrackingInfoBriefPagedResultQueryHandler : IRequestHandler<PresentTrackingInfoGetListQuery, IEnumerable<PresentTrackingInfoBriefDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPresentTrackingInfoBriefPagedResultQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PresentTrackingInfoBriefDto>> Handle(PresentTrackingInfoGetListQuery request, CancellationToken cancellationToken)
    {
        return await _context.PresentTrackingInfos
            .OrderByDescending(a => a.Id)
            .Select(b => new PresentTrackingInfoBriefDto
            {
                Id = b.Id,
                PersonId = b.PersonId,
                Latitude = b.Latitude,
                Longitude = b.Longitude,
                CreatedAt = b.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}

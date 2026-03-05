using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTrackingInfoBriefResultQueryHandler : IStreamRequestHandler<TrackingInfoGetListQuery, List<List<TrackingInfoBriefDto>>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetTrackingInfoBriefResultQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async IAsyncEnumerable<List<List<TrackingInfoBriefDto>>> Handle(
        TrackingInfoGetListQuery request,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var query = _context.TrackingInfos.AsQueryable();

        if (request.PersonId.HasValue)
            query = query.Where(a => a.PersonId == request.PersonId.Value);

        if (request.FromDate.HasValue)
            query = query.Where(a => a.DateAt >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(a => a.DateAt <= request.ToDate.Value);

        query = query.OrderByDescending(a => a.DateAt);

        var allGroups = new List<List<TrackingInfoBriefDto>>();
        var currentGroup = new List<TrackingInfoBriefDto>();
        TrackingInfoBriefDto? lastItem = null;

        await foreach (var entity in query.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            var dto = new TrackingInfoBriefDto
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
                PersonName = entity.Person?.FullName ?? string.Empty,
                DateAt = entity.DateAt,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };

            if (lastItem != null && Math.Abs((dto.DateAt - lastItem.DateAt).TotalMinutes) > 1)
            {
                if (currentGroup.Any())
                {
                    allGroups.Add(currentGroup);
                    currentGroup = new List<TrackingInfoBriefDto>();
                }
            }

            currentGroup.Add(dto);
            lastItem = dto;
        }

        if (currentGroup.Any())
            allGroups.Add(currentGroup);

        yield return allGroups;
    }
}

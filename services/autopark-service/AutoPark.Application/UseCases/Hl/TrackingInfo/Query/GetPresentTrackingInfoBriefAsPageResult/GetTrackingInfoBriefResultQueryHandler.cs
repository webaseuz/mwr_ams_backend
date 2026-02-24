using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoBriefResultQueryHandler :
    IStreamRequestHandler<GetTrackingInfoBriefResultQuery, List<List<TrackingInfoBriefDto>>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTrackingInfoBriefResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<List<List<TrackingInfoBriefDto>>> Handle(GetTrackingInfoBriefResultQuery request,
    [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TrackingInfo, TrackingInfoBriefDto>(_context.TrackingInfos)
            .SortFilter(request)
            .OrderByDescending(a => a.DateAt);

        var allGroups = new List<List<TrackingInfoBriefDto>>();
        var currentGroup = new List<TrackingInfoBriefDto>();
        TrackingInfoBriefDto lastItem = null;

        await foreach (var entity in query.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            var dto = new TrackingInfoBriefDto
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
                PersonName = entity.PersonName,
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
        {
            allGroups.Add(currentGroup);
        }

        yield return allGroups;
    }
}

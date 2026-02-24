using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModelFiles;

public static class TransportModelFileSelectList
{
    public static async Task<SelectList<Guid>> AsSelectList(this IQueryable<TransportModelFile> query,
                                                                GetTransportModelFileSelectListQuery request,
                                                                CancellationToken cancellationToken)
    {

        var filteredQuery = query;

        if (request.TransportModelId != 0)
            filteredQuery = filteredQuery.Where(x => x.TransportModelId == request.TransportModelId);

        if (request.TransportColorId != 0)
            filteredQuery = filteredQuery.Where(x => x.TransportColorId == request.TransportColorId);

        var result = await filteredQuery
            .Select(a => new TransportModelFileSelectListItem<Guid>
            {
                Value = a.Id,
                Text = a.FileName,
                TransportModelId = a.TransportModelId,
                TransportColorId = a.TransportColorId
            })
             .ToListAsync(cancellationToken);

        return [.. result];
    }
}

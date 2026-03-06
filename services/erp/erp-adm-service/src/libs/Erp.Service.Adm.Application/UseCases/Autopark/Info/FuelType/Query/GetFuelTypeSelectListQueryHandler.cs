using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetFuelTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<FuelTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(FuelTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        if (request.TransportSettingId.HasValue)
        {
            var result = await context.TransportSettings
                .Where(a => a.Id == request.TransportSettingId)
                .SelectMany(a => a.Fuels.Select(f => f.FuelType))
                .Distinct()
                .Where(x => x.StateId == WbStateIdConst.ACTIVE)
                .Select(a => new FuelTypeSelectListDto
                {
                    Value = a.Id,
                    Text = a.FullName,
                    OrderCode = a.OrderCode,
                    Id = a.Id,
                })
                .ToListAsync(cancellationToken);

            return [.. result];
        }

        var allResult = await context.FuelTypes
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new FuelTypeSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.OrderCode,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. allResult];
    }
}
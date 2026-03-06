using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetCountrySelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<CountrySelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(CountrySelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Countries
            .Select(a => new CountrySelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.OrderCode,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

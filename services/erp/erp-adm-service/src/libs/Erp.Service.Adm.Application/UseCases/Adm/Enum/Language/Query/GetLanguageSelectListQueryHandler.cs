using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetLanguageSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<LanguageSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(LanguageSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Languages
            .Select(a => new LanguageSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.Code,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

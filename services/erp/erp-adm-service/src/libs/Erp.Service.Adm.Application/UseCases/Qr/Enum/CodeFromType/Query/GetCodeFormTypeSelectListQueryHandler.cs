using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetCodeFromTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<CodeFromTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(CodeFromTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CodeFormTypes
            .Select(a => new CodeFromTypeSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}
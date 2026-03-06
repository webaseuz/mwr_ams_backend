using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetDocumentTypeSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<DocumentTypeSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(DocumentTypeSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.DocumentTypes
            .Select(a => new DocumentTypeSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

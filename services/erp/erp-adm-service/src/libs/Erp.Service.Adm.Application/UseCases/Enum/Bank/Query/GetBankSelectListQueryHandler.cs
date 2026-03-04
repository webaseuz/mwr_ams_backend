using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetBankSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<BankSelectListQuery, WbSelectList<int>>
{
    public async Task<WbSelectList<int>> Handle(BankSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Banks
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new BankSelectListDto
            {
                Value = a.Id,
                Text = a.ShortName,
                Id = a.Id,
                Code = a.BankCode,
                FullName = a.FullName,
                ShortName = a.ShortName,
                StateId = a.StateId,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

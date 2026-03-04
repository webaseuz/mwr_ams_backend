using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetPersonSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<PersonSelectListQuery, WbSelectList<int, PersonSelectListDto>>
{
    public async Task<WbSelectList<int, PersonSelectListDto>> Handle(PersonSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.People
            .Where(x => !x.IsDeleted && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new PersonSelectListDto
            {
                Value = (int)x.Id,
                Text = x.FullName,
                Id = (int)x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                FullName = x.FullName,
                ShortName = x.FullName,
                BirthOn = x.BirthOn,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

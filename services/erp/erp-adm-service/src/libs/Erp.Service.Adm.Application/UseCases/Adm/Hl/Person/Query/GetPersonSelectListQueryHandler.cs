using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetPersonSelectListQueryHandler(IApplicationDbContext context, IMainAuthService authService)
    : IRequestHandler<PersonSelectListQuery, WbSelectList<long>>
{
    public async Task<WbSelectList<long>> Handle(PersonSelectListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = authService.User;

        if (!userInfo.Permissions.Contains(nameof(AdmPermissionCode.ViewAllPerson)))
            request.BranchId = userInfo.BranchId;

        var result = await context.People
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .Select(a => new PersonSelectListDto
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.Pinfl,
                Id = a.Id,
            })
            .ToListAsync(cancellationToken);

        if (request.BranchId.HasValue)
        {
            var userPeople = await context.Users
                .Where(a => a.BranchId == request.BranchId && a.StateId == WbStateIdConst.ACTIVE)
                .Select(a => new PersonSelectListDto { Value = a.Person.Id, Text = a.Person.FullName, OrderCode = a.Person.Pinfl, Id = a.Person.Id })
                .ToListAsync(cancellationToken);

            var driverPeople = await context.Drivers
                .Where(a => a.BranchId == request.BranchId && a.StateId == WbStateIdConst.ACTIVE)
                .Select(a => new PersonSelectListDto { Value = a.Person.Id, Text = a.Person.FullName, OrderCode = a.Person.Pinfl, Id = a.Person.Id })
                .ToListAsync(cancellationToken);

            foreach (var person in userPeople)
                if (!result.Any(a => a.Value == person.Value))
                    result.Add(person);

            foreach (var person in driverPeople)
                if (!result.Any(a => a.Value == person.Value))
                    result.Add(person);
        }

        return [.. result];
    }
}
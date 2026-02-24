using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Persons;

public static class PersonSelectList
{
    public static async Task<SelectList<long>> AsSelectList(this IQueryable<Person> query,
                                                                GetPersonSelectListQuery request,
                                                               IAsyncAppAuthService appAuthService,
                                                               IReadEfCoreContext _context,
                                                               CancellationToken cancellationToken)
    {
        var user = await appAuthService.GetUserAsync();

        if (!await appAuthService.HasPermissionAsync(nameof(PermissionCode.ViewAllPerson)))
            request.BranchId = user.BranchId;

        List<Person> userPeople = new List<Person>();
        List<Person> driverPeople = new List<Person>();

        if (request.BranchId.HasValue)
        {
            userPeople = _context.Users.Where(a => a.BranchId == request.BranchId && a.StateId == StateIdConst.ACTIVE).Select(a => a.Person).ToList();
            driverPeople = _context.Drivers.Where(a => a.BranchId == request.BranchId && a.StateId == StateIdConst.ACTIVE).Select(a => a.Person).ToList();
            //query = query.Where(q => q.BranchId == request.BranchId);
        }

        var result = await query
            .IsSoftActive()
            .Select(a =>
            new PersonSelectListItem<long>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.Pinfl,
                //BranchId = a.BranchId
            })
            .ToListAsync(cancellationToken);

        foreach (var person in userPeople)
        {
            if (!result.Any(a => a.Value == person.Id))
            {
                result.Add(new PersonSelectListItem<long>
                {
                    Value = person.Id,
                    Text = person.FullName,
                    OrderCode = person.Pinfl,
                    //BranchId = person.BranchId
                });
            }

        }

        foreach (var person in driverPeople)
        {
            if (!result.Any(a => a.Value == person.Id))
            {
                result.Add(new PersonSelectListItem<long>
                {
                    Value = person.Id,
                    Text = person.FullName,
                    OrderCode = person.Pinfl,
                    //BranchId = person.BranchId
                });
            }

        }
        return [.. result];
    }
}
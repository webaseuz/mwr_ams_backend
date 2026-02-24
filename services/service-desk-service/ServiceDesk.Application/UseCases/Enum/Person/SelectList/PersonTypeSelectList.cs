using ServiceDesk.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public static class PersonTypeSelectList
{
    public static async Task<SelectList<long>> AsSelectList(this IQueryable<Person> query,
                                                               CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new PersonTypeSelectListItem<long>
            {
                Value = a.Id,
                Text = a.FullName,
                OrderCode = a.Pinfl,
                BranchId = a.BranchId,
                PhoneNumber = a.Users.Any(u => u.StateId == StateIdConst.ACTIVE) ?
                a.Users.FirstOrDefault(u => u.StateId == StateIdConst.ACTIVE).PhoneNumber :
                null
            })
            .ToListAsync(cancellationToken);

        return [.. result]; 
    }
}
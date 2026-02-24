using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Enum.CodeFromTypes;

public static class CodeFormTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<CodeFormType> query, CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
           new SelectListItem<int>
           {
               Value = a.Id,
               Text = a.ShortName,
           })
           .ToListAsync(cancellationToken);

        return [.. result];
    }
}

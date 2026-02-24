using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Enum.DocumentTypes;

public static class DocumentTypeSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<DocumentType> query, CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.Translates.AsQueryable()
                .FirstOrDefault(DocumentTypeTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? a.FullName,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

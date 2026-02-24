using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Enums;

public static class LanguageSelectList
{
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Language> query,
                                                                CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new SelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.Code
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }


    //This is second way of creating I have created custom SelectlistItem class .if you want add extra things to model you need create your own
    /*
    public static async Task<SelectList<int>> AsSelectList(this IQueryable<Language> query,
                                                                CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new LanguageSelectListItem<int>
            {
                Value = a.Id,
                Text = a.ShortName,
                OrderCode = a.Code,
                FullName = a.FullName
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
     
     
     */
}

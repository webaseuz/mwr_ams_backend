using AutoPark.Domain;
using Bms.WEBASE.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.NotificationTemplates;

public static class NotificationTemplateSelectList
{
    public static async Task<SelectList<long>> AsSelectList(
        this IQueryable<NotificationTemplate> query,
        CancellationToken cancellationToken)
    {
        var result = await query.Select(a =>
            new NotificationTemplateSelectListItem<long>
            {
                Value = a.Id,
                Key = a.Key,
                Text = a.Subject,
                Message = a.Message
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;


namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetNotificationTemplateSelectListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<NotificationTemplateSelectListQuery, WbSelectList<long>>
{
    public async Task<WbSelectList<long>> Handle(NotificationTemplateSelectListQuery request, CancellationToken cancellationToken)
    {
        var result = await context.NotificationTemplates
            .Select(a => new NotificationTemplateSelectListDto
            {
                Value = a.Id,
                Text = a.Subject,
                Id = a.Id,
                Key = a.Key,
                Message = a.Message,
            })
            .ToListAsync(cancellationToken);

        return [.. result];
    }
}

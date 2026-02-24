using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplates;

public class GetNotificationTemplateSelectListQueryHandler :
    IRequestHandler<GetNotificationTemplateSelectListQuery, SelectList<long>>
{
    private readonly IReadEfCoreContext _context;
    public GetNotificationTemplateSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<long>> Handle(
        GetNotificationTemplateSelectListQuery request,
        CancellationToken cancellationToken)
        => await _context.NotificationTemplates
            .AsSelectList(cancellationToken);
}

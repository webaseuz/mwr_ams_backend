using MediatR;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionDeleteCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

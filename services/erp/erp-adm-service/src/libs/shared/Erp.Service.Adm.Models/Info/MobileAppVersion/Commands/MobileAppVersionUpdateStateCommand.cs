using MediatR;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionUpdateStateCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public int StateId { get; set; }
}

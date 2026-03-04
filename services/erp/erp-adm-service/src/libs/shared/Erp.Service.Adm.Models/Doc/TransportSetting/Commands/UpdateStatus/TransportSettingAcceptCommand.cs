using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportSettingAcceptCommand : IRequest<bool>
{
    public long Id { get; set; }
}

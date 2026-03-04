using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportSettingCancelCommand : IRequest<bool>
{
    public long Id { get; set; }
}

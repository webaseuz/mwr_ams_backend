using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportSettingDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}

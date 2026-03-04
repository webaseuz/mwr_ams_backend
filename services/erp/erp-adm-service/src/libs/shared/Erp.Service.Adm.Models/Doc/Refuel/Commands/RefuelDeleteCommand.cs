using MediatR;

namespace Erp.Service.Adm.Models;

public class RefuelDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}

using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseSendCommand : IRequest<bool>
{
    public long Id { get; set; }
}

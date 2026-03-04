using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseRevokeCommand : IRequest<bool>
{
    public long Id { get; set; }
}

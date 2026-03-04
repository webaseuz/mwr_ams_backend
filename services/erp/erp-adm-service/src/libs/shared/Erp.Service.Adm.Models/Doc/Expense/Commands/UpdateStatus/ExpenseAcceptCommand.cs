using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseAcceptCommand : IRequest<bool>
{
    public long Id { get; set; }
}

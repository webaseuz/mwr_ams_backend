using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}

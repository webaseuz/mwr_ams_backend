using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseCancelCommand : IRequest<bool>
{
    public long Id { get; set; }
}

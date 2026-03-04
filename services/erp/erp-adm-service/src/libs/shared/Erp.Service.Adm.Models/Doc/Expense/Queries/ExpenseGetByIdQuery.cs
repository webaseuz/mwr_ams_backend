using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseGetByIdQuery : IRequest<ExpenseDto>
{
    public long Id { get; set; }
}

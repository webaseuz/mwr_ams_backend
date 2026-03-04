using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseGetByIdQuery : IRequest<ItemOfExpenseDto>
{
    public int Id { get; set; }
}



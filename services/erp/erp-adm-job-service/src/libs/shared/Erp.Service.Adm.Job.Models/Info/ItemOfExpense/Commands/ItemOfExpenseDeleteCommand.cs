using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

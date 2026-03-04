using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseGetByCodeQuery : IRequest<int?>
{
    public string Code { get; set; } = null;
}



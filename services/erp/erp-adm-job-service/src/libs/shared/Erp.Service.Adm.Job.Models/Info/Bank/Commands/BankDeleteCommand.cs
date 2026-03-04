using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class BankDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

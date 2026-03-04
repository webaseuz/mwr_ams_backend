using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class BankGetByIdQuery : IRequest<BankDto>
{
    public int Id { get; set; }
}

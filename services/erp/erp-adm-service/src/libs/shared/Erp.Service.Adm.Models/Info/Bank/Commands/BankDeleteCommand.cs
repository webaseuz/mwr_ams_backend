using MediatR;

namespace Erp.Service.Adm.Models;
public class BankDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

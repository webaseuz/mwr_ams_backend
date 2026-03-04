using MediatR;

namespace Erp.Service.Adm.Models;

public class CurrencyDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

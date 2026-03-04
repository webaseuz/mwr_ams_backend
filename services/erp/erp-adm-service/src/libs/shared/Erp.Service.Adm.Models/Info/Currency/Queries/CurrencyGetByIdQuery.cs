using MediatR;

namespace Erp.Service.Adm.Models;

public class CurrencyGetByIdQuery : IRequest<CurrencyDto>
{
    public int Id { get; set; }
}

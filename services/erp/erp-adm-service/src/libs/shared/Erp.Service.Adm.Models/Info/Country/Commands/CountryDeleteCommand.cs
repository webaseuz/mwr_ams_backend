using MediatR;

namespace Erp.Service.Adm.Models;

public class CountryDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

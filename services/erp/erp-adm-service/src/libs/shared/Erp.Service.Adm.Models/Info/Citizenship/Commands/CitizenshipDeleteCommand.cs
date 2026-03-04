using MediatR;

namespace Erp.Service.Adm.Models;

public class CitizenshipDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

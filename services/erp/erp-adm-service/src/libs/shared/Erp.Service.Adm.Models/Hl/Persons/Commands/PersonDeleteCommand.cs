using MediatR;

namespace Erp.Service.Adm.Models;
public class PersonDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}


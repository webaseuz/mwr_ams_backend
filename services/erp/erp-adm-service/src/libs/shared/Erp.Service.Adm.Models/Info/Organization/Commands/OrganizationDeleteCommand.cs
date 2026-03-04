using MediatR;

namespace Erp.Service.Adm.Models;

public class OrganizationDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

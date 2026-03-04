using MediatR;

namespace Erp.Service.Adm.Models;

public class DepartmentDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

using MediatR;

namespace Erp.Service.Adm.Models;

public class DepartmentGetByIdQuery : IRequest<DepartmentDto>
{
    public int Id { get; set; }
}

using MediatR;

namespace Erp.Service.Adm.Models;

public class BranchGetByIdQuery : IRequest<BranchDto>
{
    public int Id { get; set; }
}

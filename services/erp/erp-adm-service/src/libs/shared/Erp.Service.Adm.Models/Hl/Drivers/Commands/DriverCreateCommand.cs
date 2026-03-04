using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DriverCreateCommand : IRequest<WbHaveId<int>>
{
    public int BranchId { get; set; }
    public DriverPersonCreateCommand Person { get; set; } = null!;
    public List<DriverDocumentCreateCommand> Documents { get; set; } = new();
}

using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public DriverPersonUpdateCommand Person { get; set; } = null!;
    public List<DriverDocumentUpdateCommand> Documents { get; set; } = new();
}

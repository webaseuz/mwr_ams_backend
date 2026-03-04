using MediatR;

namespace Erp.Service.Adm.Models;

public class DepartmentUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public List<DepartmentTranslateCommand> Translates { get; set; } = new();
}

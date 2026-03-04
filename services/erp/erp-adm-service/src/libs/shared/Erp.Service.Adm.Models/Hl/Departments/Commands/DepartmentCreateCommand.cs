using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DepartmentCreateCommand : IRequest<WbHaveId<int>>
{
    public int BranchId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public List<DepartmentTranslateCommand> Translates { get; set; } = new();
}

using MediatR;
using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Departments;

public class CreateDepartmentCommand :
    IRequest<IHaveId<int>>
{
    public int BranchId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string OrderCode { get; set; }

    public List<DepartmentTranslateCommand> Translates { get; set; }
}

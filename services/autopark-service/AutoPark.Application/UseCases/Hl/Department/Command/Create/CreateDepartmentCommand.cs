using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class CreateDepartmentCommand :
    IRequest<IHaveId<int>>
{
    public int OrganizationId { get; set; }
    public int BranchId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string OrderCode { get; set; }

    public List<DepartmentTranslateCommand> Translates { get; set; }
}

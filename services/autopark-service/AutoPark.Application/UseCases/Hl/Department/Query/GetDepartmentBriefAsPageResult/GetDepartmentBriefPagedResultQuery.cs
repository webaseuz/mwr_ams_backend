using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class GetDepartmentBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<DepartmentBriefDto>>
{
    public int? BranchId { get; set; }
}
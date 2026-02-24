using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentSelectListQuery : IRequest<SelectList<int>>
{
    public int? BranchId { get; set; }

}

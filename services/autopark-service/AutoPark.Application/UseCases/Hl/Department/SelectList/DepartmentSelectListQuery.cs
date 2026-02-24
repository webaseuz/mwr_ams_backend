using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class DepartmentSelectListQuery : IRequest<SelectList<int>>
{
    public int? BranchId { get; set; }

}

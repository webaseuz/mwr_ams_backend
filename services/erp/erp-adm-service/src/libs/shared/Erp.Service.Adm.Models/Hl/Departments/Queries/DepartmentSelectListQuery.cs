using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DepartmentSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? BranchId { get; set; }
}

using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class UserSelectListQuery : IRequest<WbSelectList<int>>
{
    public List<int> Roles { get; set; } = new();
    public int? BranchId { get; set; }
}
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class GetUserSelectListQuery :
    IRequest<SelectList<int>>
{
    public List<int> Roles { get; set; } = new List<int>();
    public int? BranchId { get; set; }
}

using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class GetRoleSelectListQuery :
    IRequest<SelectList<int>>
{
}

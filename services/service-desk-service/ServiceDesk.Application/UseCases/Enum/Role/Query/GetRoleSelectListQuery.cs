using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleSelectListQuery :
	IRequest<SelectList<int>>
{
}

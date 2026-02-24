using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class DeleteRoleCommand :
	IRequest<SuccessResult<bool>>
{
	public int Id { get; set; }
}

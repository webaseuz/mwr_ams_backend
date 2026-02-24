using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class CreateRoleCommand :
	IRequest<IHaveId<int>>
{
	public string OrderCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public bool IsAdmin { get; set; }
	public List<RoleTranslateCommand> Translates { get; set; } = new();
	public List<int> RolePermissions { get; set; }
}
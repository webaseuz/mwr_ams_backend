using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class UpdateRoleCommand :
	IHaveIdProp<int>,
	IRequest<IHaveId<int>>
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string ShortName { get; set; }
	public string FullName { get; set; }
	public bool IsAdmin { get; set; }
	public List<RoleTranslateCommand> Translates { get; set; } = new();
	public List<int> RolePermissions { get; set; }
}

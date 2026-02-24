namespace ServiceDesk.Application.UseCases.Roles;

public class RoleDto
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public bool IsAdmin { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; } = null!;
	public List<RoleTranslateDto> Translates { get; set; } = new();
	public List<int> RolePermissions { get; set; } = new();	
}

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleBriefDto
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string ShortName { get; set; }
	public string FullName { get; set; }
	public bool IsAdmin { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
}

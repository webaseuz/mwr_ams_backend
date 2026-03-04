namespace Erp.Service.Adm.Job.Models;
public class UserBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public int PersonId { get; set; }
    public int OrganizationId { get => UserOrganizations.FirstOrDefault()?.OrganizationId ?? 0; }
    public string OrganizationName { get => UserOrganizations.FirstOrDefault()?.OrganizationName; }
    public PersonBriefDto Person { get; set; }
    public List<UserRoleBriefDto> UserRoles { get; set; } = new();
    public List<UserOrganizationBriefDto> UserOrganizations { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}

namespace Erp.Service.Adm.Job.Models;

public class UserOrganizationCreateDto
{
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public int StateId { get; set; }
}

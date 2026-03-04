namespace Erp.Service.Adm.Models;

public class UserOrganizationBriefDto
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public string Inn { get; set; }
    public string OrganizationName { get; set; }
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
}

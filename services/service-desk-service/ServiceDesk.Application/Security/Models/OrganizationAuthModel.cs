namespace ServiceDesk.Application;

public class OrganizationAuthModel
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int? RegionId { get; set; }
    public string Inn { get; set; }
}

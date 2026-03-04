namespace Erp.Service.Adm.Models;
public class UserPrintAsExcelDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string IdentityKey { get; set; }
    public string FullName { get; set; }
    public string OrganizationNames { get; set; }
    public string Roles { get; set; }
    public string PhoneNumber { get; set; }
    public string State { get; set; }
}

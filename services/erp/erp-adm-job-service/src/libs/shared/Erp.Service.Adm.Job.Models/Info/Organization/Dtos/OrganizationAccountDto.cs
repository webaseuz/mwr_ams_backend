namespace Erp.Service.Adm.Job.Models;
public class OrganizationAccountDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Shghr { get; set; }
    public int OwnerId { get; set; }
    public string Organization { get; set; }
    public int BankId { get; set; }
    public string Bank { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public List<OrganizationAccountTranslateDto> Translates { get; set; } = new List<OrganizationAccountTranslateDto>();
}

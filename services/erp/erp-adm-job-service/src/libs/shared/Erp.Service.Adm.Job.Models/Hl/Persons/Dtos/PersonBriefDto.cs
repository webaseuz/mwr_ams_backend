namespace Erp.Service.Adm.Job.Models;
public class PersonBriefDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public DateTime? BirthOn { get; set; }
}

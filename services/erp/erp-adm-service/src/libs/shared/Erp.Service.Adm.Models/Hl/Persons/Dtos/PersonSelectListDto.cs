using WEBASE;

namespace Erp.Service.Adm.Models;
public class PersonSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public DateTime? BirthOn { get; set; }

}

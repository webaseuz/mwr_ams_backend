using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CountrySelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string SoatoCode { get; set; }
    public string RoamingCode { get; set; }
    public string TextCode { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}



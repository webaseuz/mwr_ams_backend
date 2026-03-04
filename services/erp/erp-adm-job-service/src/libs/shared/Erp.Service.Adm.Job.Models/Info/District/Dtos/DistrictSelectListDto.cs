using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class DistrictSelectListDto : WbSelectListItem<int>
{
    public int id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string DistrictCode { get; set; }
    public int State { get; set; }
}

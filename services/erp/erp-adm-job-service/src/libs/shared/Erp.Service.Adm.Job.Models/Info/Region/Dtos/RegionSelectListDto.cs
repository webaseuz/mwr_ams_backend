using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class RegionSelectListDto : WbSelectListItem<int>
{
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string SoatoCode { get; set; }
    public string RoamingCode { get; set; }
    public string RegionCode { get; set; }
}

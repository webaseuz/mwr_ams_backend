using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class MfySelectListDto : WbSelectListItem<int>
{
    public string Inn { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }
    public int RegionId { get; set; }
    public string Region { get; set; }
    public int DistrictId { get; set; }
    public string District { get; set; }
    public string Soato { get; set; }

}

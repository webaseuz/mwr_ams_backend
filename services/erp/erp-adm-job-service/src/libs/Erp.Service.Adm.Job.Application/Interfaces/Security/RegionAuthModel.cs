using Erp.Core.Security;

namespace Erp.Service.Adm.Job.Application;

public class RegionAuthModel : IRegionAuthModel
{
    public int Id { get; set; }
    public string RegionName { get; set; }
    public string DistrictName { get; set; }
    public int RegionId { get; set; }
    public int? DistrictId { get; set; }
    public int AppId { get; set; }
    public List<IMfyAuthModel> Mfys { get; set; }
}

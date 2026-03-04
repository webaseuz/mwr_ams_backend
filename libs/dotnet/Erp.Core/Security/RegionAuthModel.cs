namespace Erp.Core.Security;

public interface IRegionAuthModel
{
    string RegionName { get; set; }
    string DistrictName { get; set; }
    int RegionId { get; set; }
    int? DistrictId { get; set; }
    int AppId { get; set; }
    public List<IMfyAuthModel> Mfys { get; set; }
}

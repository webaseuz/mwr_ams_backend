using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class DistrictCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string DistrictCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int RegionId { get; set; }
    public int StateId { get; set; }
    public bool IsCenter { get; set; }

    public List<DistrictTranslateCreateUpdateCommand> Translates { get; set; } = new List<DistrictTranslateCreateUpdateCommand>();
}

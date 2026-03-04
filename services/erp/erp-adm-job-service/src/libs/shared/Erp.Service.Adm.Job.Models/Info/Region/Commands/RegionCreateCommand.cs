using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class RegionCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string RoamingCode { get; set; }
    public string RegionCode { get; set; }
    public string SoatoCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<RegionTranslateCreateUpdateCommand> Translates { get; set; } = new List<RegionTranslateCreateUpdateCommand>();
}

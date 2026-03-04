using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class MfyUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public int RegionId { get; set; }
    public int StateId { get; set; }
    public int DistrictId { get; set; }
    public string Soato { get; set; }
}

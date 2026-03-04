using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class MfySelectListQuery : IRequest<WbSelectList<int, MfySelectListDto>>
{
    public int? DistrictId { get; set; }
    public int? RegionId { get; set; }

}

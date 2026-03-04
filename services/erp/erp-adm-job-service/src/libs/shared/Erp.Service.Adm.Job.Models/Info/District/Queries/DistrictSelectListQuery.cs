using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class DistrictSelectListQuery : IRequest<WbSelectList<int, DistrictSelectListDto>>
{
    public bool? IsCenter { get; set; }
    public int RegionId { get; set; }
}

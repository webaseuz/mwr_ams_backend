using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class DistrictGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DistrictDto>>
{
    public int? RegionId { get; set; }

    public int StateId { get; set; }
}

using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DistrictGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DistrictBriefDto>>
{
    public int StateId { get; set; }
}

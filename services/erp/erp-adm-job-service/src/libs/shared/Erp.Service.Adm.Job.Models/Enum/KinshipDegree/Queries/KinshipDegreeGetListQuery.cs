using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class KinshipDegreeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<KinshipDegreeBriefDto>>
{
    public int StateId { get; set; }
}

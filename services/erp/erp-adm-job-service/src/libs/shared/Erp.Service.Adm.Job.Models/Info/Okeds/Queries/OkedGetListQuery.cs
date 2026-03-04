using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OkedGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<OkedBriefDto>>
{
    public int StateId { get; set; }
}


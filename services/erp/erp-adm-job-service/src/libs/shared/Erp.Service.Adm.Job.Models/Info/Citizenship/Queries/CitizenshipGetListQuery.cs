using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CitizenshipGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<CitizenshipBriefDto>>
{
    public int StateId { get; set; }
}

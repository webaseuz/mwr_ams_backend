using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class SpecialtyGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<SpecialtyBriefDto>>
{
    public int StateId { get; set; }
}

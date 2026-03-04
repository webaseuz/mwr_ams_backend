using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<EduDirectionBriefDto>>
{
    public int StateId { get; set; }
}

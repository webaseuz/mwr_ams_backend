using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduYearGetListQuery : WbSortFilterPageOptions,
IRequest<WbPagedResult<EduYearBriefDto>>
{
    public int StateId { get; set; }
}

using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<FixedMinimumValueBriefDto>>
{
    public int? StateId { get; set; }
    public int? MinimumValueTypeId { get; set; }
    public DateTime? DateOn { get; set; }

}

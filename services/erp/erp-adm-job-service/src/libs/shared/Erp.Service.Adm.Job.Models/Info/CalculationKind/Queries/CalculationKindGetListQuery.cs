using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculationKindGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<CalculationKindBriefDto>>
{
    public int StateId { get; set; }
}

using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class StateGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<StateBriefDto>>
{
}

using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class StatusGetListQuery : WbSortFilterPageOptions,
IRequest<WbPagedResult<StatusBriefDto>>
{
}

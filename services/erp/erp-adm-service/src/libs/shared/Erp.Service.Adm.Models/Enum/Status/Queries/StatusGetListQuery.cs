using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class StatusGetListQuery : WbSortFilterPageOptions,
IRequest<WbPagedResult<StatusBriefDto>>
{
}

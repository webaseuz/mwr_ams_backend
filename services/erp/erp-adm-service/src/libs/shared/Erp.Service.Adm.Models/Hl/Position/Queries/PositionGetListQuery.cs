using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PositionGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<PositionBriefDto>>
{
}

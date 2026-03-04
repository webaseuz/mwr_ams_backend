using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class BranchGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<BranchBriefDto>>
{
}

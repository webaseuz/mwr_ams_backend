using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportModelBriefDto>>
{
}

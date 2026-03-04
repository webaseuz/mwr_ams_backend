using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class TableGetListQuery : WbSortFilterPageOptions,
IRequest<WbPagedResult<TableBriefDto>>
{
}

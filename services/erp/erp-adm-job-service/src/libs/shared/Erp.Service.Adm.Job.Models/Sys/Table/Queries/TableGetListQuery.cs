using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class TableGetListQuery : WbSortFilterPageOptions,
IRequest<WbPagedResult<TableBriefDto>>
{
}

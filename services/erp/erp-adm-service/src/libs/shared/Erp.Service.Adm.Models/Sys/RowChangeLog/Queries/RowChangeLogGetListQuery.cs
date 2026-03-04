using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class RowChangeLogGetListQuery : WbSortFilterPageOptions, IRequest<List<RowChangeLogBriefDto>>
{
    public int TableId { get; set; }
    public long RowId { get; set; }
}

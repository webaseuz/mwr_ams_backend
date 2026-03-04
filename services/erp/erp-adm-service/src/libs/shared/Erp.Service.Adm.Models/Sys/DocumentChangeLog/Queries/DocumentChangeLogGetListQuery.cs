using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DocumentChangeLogGetListQuery : WbSortFilterPageOptions, IRequest<List<DocumentChangeLogBriefDto>>
{
    public int TableId { get; set; }
    public long DocId { get; set; }
}

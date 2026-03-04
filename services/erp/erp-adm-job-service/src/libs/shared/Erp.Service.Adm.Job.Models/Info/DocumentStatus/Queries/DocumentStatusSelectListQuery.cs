using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusSelectListQuery : IRequest<WbSelectList<int>>
{
    public int TableId { get; set; }
}

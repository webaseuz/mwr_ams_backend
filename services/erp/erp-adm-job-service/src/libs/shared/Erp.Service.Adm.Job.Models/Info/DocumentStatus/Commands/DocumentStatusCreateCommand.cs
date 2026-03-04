using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }

    public int TableId { get; set; }
    public int? StateId { get; set; }
    public List<DocumentStatusTableDto> Tables { get; set; } = new();
}

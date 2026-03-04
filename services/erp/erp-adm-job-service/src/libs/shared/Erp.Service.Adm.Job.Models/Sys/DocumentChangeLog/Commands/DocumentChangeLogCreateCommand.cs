using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentChangeLogCreateCommand : IRequest<WbHaveId<long>>
{
    public int TableId { get; set; }
    public long DocId { get; set; }
    public int StatusId { get; set; }
    public int UserId { get; set; }
    public string UserInfo { get; set; } = null!;
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string Message { get; set; }

    public int? OrganizationId { get; set; }
    public DateTime DateAt { get; set; } = DateTime.Now;

    public string DocumentDto { get; set; } = null!;
}

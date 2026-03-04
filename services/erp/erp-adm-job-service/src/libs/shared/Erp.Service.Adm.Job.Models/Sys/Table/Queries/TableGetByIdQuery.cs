using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class TableGetByIdQuery : IRequest<TableDto>
{
    public int Id { get; set; }
}

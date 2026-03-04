using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Models;
public class TableGetByIdQuery : IRequestGetByIdQuery<int, TableDto>
{
    public int Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}

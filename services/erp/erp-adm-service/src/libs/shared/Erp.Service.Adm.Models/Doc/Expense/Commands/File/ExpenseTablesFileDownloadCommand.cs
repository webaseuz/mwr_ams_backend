using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseTablesFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
    public string DocumentName { get; set; }
}

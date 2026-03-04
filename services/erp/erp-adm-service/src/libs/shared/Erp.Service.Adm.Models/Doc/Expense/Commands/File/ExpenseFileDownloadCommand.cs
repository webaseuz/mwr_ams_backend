using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseFileDownloadCommand : IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}

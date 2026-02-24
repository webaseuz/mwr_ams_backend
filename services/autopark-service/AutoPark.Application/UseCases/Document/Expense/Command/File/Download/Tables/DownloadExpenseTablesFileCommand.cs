using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadExpenseTablesFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
    public string DocumentName { get; set; }
}

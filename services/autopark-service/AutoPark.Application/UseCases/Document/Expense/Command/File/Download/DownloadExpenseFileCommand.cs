using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class DownloadExpenseFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid FileId { get; set; }
}

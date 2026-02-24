using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class DownloadRefuelFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

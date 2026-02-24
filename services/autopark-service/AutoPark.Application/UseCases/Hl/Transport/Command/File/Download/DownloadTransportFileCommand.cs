using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class DownloadTransportFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

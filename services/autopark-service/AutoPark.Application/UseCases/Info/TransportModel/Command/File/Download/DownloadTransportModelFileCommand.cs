using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class DownloadTransportModelFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

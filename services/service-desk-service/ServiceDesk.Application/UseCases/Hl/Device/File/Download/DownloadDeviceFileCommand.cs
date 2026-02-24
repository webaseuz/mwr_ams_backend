using MediatR;

namespace ServiceDesk.Application.UseCases.Devices;

public class DownloadDeviceFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}


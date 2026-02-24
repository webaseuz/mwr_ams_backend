using MediatR;

namespace AutoPark.Application.UseCases.TransportSettings;

public class DownloadTransportSettingFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

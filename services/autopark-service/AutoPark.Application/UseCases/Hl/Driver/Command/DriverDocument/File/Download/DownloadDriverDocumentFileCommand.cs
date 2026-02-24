using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class DownloadDriverDocumentFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

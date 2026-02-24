using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class DownloadServiceApplicationFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

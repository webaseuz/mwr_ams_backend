using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class DownloadPersonFileCommand :
    IRequest<(byte[], string)?>
{
    public Guid fileId { get; set; }
}

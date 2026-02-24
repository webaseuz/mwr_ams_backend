namespace AutoPark.Application.UseCases.Transports;

public class UpdateTransportFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

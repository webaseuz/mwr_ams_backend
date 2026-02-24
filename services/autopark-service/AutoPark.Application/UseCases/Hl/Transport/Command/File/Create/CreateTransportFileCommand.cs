namespace AutoPark.Application.UseCases.Transports;

public class CreateTransportFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

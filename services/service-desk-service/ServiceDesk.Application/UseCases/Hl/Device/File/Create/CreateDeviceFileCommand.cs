namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

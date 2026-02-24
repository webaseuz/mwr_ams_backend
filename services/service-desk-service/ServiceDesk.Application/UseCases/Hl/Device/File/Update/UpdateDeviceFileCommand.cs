namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

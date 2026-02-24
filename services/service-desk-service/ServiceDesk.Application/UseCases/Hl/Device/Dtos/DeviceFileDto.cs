namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceFileDto
{
    public Guid Id { get; set; }
    public int OwnerId { get; set; }
    public string FileName { get; set; }
}

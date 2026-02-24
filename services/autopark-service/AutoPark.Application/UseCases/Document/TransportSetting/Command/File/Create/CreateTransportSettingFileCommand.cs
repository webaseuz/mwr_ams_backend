namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

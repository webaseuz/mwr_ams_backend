namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingFileCommand
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; } = null!;
}

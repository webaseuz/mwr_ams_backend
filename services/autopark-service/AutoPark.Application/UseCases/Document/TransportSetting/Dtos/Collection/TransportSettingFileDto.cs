namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingFileDto
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; }
}
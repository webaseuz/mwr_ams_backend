namespace AutoPark.Application.UseCases.Transports;

public class TransportFileDto
{
    public Guid Id { get; set; }
    public int OwnerId { get; set; }
    public string FileName { get; set; }
}
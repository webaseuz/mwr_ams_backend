namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelFileDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public int OwnerId { get; set; }
    public int TransportColorId { get; set; }
    public string TransportColorName { get; set; }
}

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelFileCommand
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public int TransportColorId { get; set; }
}
